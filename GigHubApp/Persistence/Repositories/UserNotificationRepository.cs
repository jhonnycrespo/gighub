using GigHubApp.Core.Models;
using GigHubApp.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GigHubApp.Persistence.Repositories
{
    public class UserNotificationRepository : IUserNotificationRepository
    {
        private readonly GigHubContext _context;

        public UserNotificationRepository(GigHubContext context)
        {
            _context = context;
        }

        public IEnumerable<UserNotification> GetUserNotificationsFor(string userId)
        {
            return _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .ToList();
        }
    }
}