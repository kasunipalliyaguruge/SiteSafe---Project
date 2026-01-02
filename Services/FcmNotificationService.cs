using System;
using FirebaseAdmin.Messaging;
using Microsoft.EntityFrameworkCore;
using SiteSafe4.Data;

namespace SiteSafe4.Services
{
    public class FcmNotificationService
    {
        private readonly ApplicationDbContext _db;

        public FcmNotificationService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task SendViolationAlertAsync(string messageBody)
        {
            var tokens = await _db.SupervisorDevices
                .Select(d => d.FcmToken)
                .ToListAsync();

            foreach (var token in tokens)
            {
                var message = new Message
                {
                    Token = token,
                    Notification = new Notification
                    {
                        Title = "🚨 SiteSafe Alert",
                        Body = messageBody
                    }
                };

                await FirebaseMessaging.DefaultInstance.SendAsync(message);
            }
        }
    }
}
