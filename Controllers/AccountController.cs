using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiteSafe4.Models;
using SiteSafe4.Services;
using SiteSafe4.ViewModels;
using System.Threading.Tasks;

namespace SiteSafe4.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailSender _emailSender;

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        /* ================= REGISTER ================= */

        [HttpGet]
        public IActionResult Register()
        {
            ViewData["HideNavbar"] = true;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            ViewData["HideNavbar"] = true;

            if (!ModelState.IsValid)
                return View(model);

            var user = new AppUser
            {
                UserName = model.Username,
                Email = model.Email,
                UniqueId = model.UniqueId,
                Role = model.Role
            };

            var result = await _userManager.CreateAsync(user, model.Password!);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account"); // ✅ FIXED typo
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        /* ================= LOGIN ================= */

        [HttpGet]
        public IActionResult Login()
        {
            ViewData["HideNavbar"] = true;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            ViewData["HideNavbar"] = true;

            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByNameAsync(model.Username!);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(
                user.UserName!,
                model.Password!,
                model.RememberMe,
                lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            ModelState.AddModelError("", "Invalid username or password");
            return View(model);
        }

        /* ================= LOGOUT ================= */

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        /* ================= FORGOT PASSWORD ================= */

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            ViewData["HideNavbar"] = true;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM model)
        {
            ViewData["HideNavbar"] = true;

            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email!);

            // 🔒 SECURITY: Always show confirmation even if email not found
            if (user == null)
                return View("ForgotPasswordConfirmation");

            // 🔥 Generate and URL-encode the token
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            token = System.Net.WebUtility.UrlEncode(token);

            // 🔥 Generate reset link
            var resetLink = Url.Action(
                "ResetPassword",
                "Account",
                new { token, email = model.Email },
                Request.Scheme
            );

            // 🔥 Email body with clickable link and raw URL fallback
            var body = $@"
        <h3>SiteSafe Password Reset</h3>
        <p>You requested a password reset.</p>
        <p><a href='{resetLink}'>Reset Password</a></p>
        <p>If the button does not work, copy and paste this link:</p>
        <p>{resetLink}</p>
        <p>If you did not request this, please ignore this email.</p>
    ";

            // 🔥 Send email via SendGrid
            await _emailSender.SendEmailAsync(
                model.Email!,
                "SiteSafe - Password Reset",
                body
            );

            return View("ForgotPasswordConfirmation");
        }

        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            ViewData["HideNavbar"] = true;
            return View(new ResetPasswordVM { Token = token, Email = email });
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            ViewData["HideNavbar"] = true;

            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email!);
            if (user == null)
            {
                // Security: do not reveal user existence
                return RedirectToAction("Login");
            }

            // 🔑 Decode the token
            var decodedToken = System.Net.WebUtility.UrlDecode(model.Token!);

            // 🔑 Reset the password
            var result = await _userManager.ResetPasswordAsync(user, decodedToken, model.Password!);

            if (result.Succeeded)
            {
                // Optional: automatically log in user after reset
                await _signInManager.SignInAsync(user, isPersistent: false);

                // Redirect to Dashboard or Login
                return RedirectToAction("Index", "Dashboard");
            }

            // Show errors if reset failed
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }


    }
}
