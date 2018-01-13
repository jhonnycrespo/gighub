using AutoMapper;
using GigHubApp.Core;
using GigHubApp.Core.DTOs;
using GigHubApp.Core.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebGrease.Css.Extensions;

namespace GigHubApp.Controllers.API
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        //private GigHubContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public NotificationsController(IUnitOfWork unitOfWork)
        {
            //_context = new GigHubContext();
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<NotificationDTO> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            //var notifications = _context.UserNotifications
            //    .Where(un => un.UserId == userId && !un.IsRead)
            //    .Select(un => un.Notification)
            //    .Include(n => n.Gig.Artist)
            //    .ToList();
            var notifications = _unitOfWork.Notifications.GetNewNotificationsFor(userId);

            return notifications.Select(n => Mapper.Map<Notification, NotificationDTO>(n));
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();
            //var notifications = _context.UserNotifications
            //    .Where(un => un.UserId == userId && !un.IsRead)
            //    .ToList();
            var notifications = _unitOfWork.UserNotifications.GetUserNotificationsFor(userId);

            notifications.ForEach(n => n.Read());

            //_context.SaveChanges();
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
