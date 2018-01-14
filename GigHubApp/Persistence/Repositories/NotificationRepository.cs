using GigHubApp.Core.Models;
using GigHubApp.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GigHubApp.Persistence.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly IGigHubContext _context;

        public NotificationRepository(IGigHubContext context)
        {
            _context = context;
        }

        public IEnumerable<Notification> GetNewNotificationsFor(string userId)
        {
            return _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Gig.Artist)
                .ToList();
        }
    }
}