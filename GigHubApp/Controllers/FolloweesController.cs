using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using GigHubApp.Core.Models;
using GigHubApp.Persistence;

namespace GigHubApp.Controllers
{
    public class FolloweesController : Controller
    {
        private GigHubContext _context;

        public FolloweesController()
        {
            _context = new GigHubContext();
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var artists = _context.Followings
                .Where(f => f.FollowerId == userId)
                .Select(f => f.Followee)
                .ToList();

            return View(artists);
        }
    }
}