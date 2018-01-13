using GigHubApp.Core;
using GigHubApp.Core.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GigHubApp.Controllers
{
    public class HomeController : Controller
    {
        //private GigHubContext _context;
        //private readonly AttendanceRepository _attendanceRepository;

        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            //_context = new GigHubContext();
            //_attendanceRepository = new AttendanceRepository(_context);
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index(string query = null)
        {
            //var upcomingGigs = _context.Gigs
            //    .Include(g => g.Artist)
            //    .Include(g => g.Genre)
            //    .Where(g => g.DateTime > DateTime.Now && !g.IsCanceled);

            var upcomingGigs = _unitOfWork.Gigs.GetUpcomingGigs(query);

            //if (!String.IsNullOrWhiteSpace(query))
            //{
            //    upcomingGigs = upcomingGigs
            //        .Where(g => g.Artist.Name.Contains(query) || g.Genre.Name.Contains(query) || g.Venue.Contains(query));
            //}

            var userId = User.Identity.GetUserId();

            //var attendances = _attendanceRepository.GetFutureAttendances(userId)
            //    .ToLookup(a => a.GigId);

            var attendances = _unitOfWork.Attendances.GetFutureAttendances(userId)
                .ToLookup(a => a.GigId);

            var viewModel = new GigsViewModel
            {
                UpcomingGigs = upcomingGigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming Gigs",
                SearchTerm = query,
                Attendances = attendances
            };

            return View("Gigs", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}