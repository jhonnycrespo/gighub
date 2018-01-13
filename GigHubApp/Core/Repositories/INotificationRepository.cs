using GigHubApp.Core.Models;
using System.Collections.Generic;

namespace GigHubApp.Core.Repositories
{
    public interface INotificationRepository
    {
        IEnumerable<Notification> GetNewNotificationsFor(string userId);
    }
}
