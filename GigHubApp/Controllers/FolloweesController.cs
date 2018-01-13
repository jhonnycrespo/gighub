using GigHubApp.Core;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace GigHubApp.Controllers
{
    public class FolloweesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FolloweesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            //var artists = _context.Followings
            //    .Where(f => f.FollowerId == userId)
            //    .Select(f => f.Followee)
            //    .ToList();

            var artists = _unitOfWork.Users.GetArtistsFollowedBy(userId);

            return View(artists);
        }
    }
}