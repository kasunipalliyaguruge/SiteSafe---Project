using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SiteSafe4.Data;
using SiteSafe4.Models;
using SiteSafe4.Services;
using SiteSafe4.Hubs;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

var builder = WebApplication.CreateBuilder(args);

// ================= DATABASE =================
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ================= IDENTITY =================
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// ================= SIGNALR =================
builder.Services.AddSignalR(); // ✅ ADD THIS

// ================= EMAIL =================
builder.Services.AddTransient<IEmailSender, SendGridEmailSender>();

// ================= MVC =================
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<FcmNotificationService>();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials()
              .WithOrigins("http://localhost:7162"); // <-- your frontend URL/port
    });
});
var app = builder.Build();

// ================= PIPELINE =================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
FirebaseApp.Create(new AppOptions
{
    Credential = GoogleCredential.FromFile("Firebase/firebase-admin.json")
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
// ================= SIGNALR HUB =================
app.MapHub<AlertHub>("/alertHub"); // ✅ ADD THIS (before MapControllerRoute)

// ================= ROUTES =================
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
