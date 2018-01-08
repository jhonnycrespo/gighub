using AutoMapper;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using GigHubApp.Core.DTOs;
using GigHubApp.Core.Models;
using GigHubApp.Persistence;

namespace GigHubApp.Controllers.API
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private GigHubContext _context;

        public NotificationsController()
        {
            _context = new GigHubContext();
        }

        public IEnumerable<NotificationDTO> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Gig.Artist)
                .ToList();

            return notifications.Select(n => Mapper.Map<Notification, NotificationDTO>(n));
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .ToList();

            notifications.ForEach(n => n.Read());

            _context.SaveChanges();

            return Ok();
        }
    }
}
