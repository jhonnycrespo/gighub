using GigHubApp.Models;
using GigHubApp.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GigHubApp.Controllers
{
    public class GigsController : Controller
    {
        private readonly GigHubContext _context;

        public GigsController()
        {
            _context = new GigHubContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            // no podemos hacer esto, EF no sabe como convertir User.Identity.GetUserId() a codigo sql
            // var artist = _context.Users.Single(u => u.Id == User.Identity.GetUserId());

            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = DateTime.Parse(string.Format("{0} {1}", viewModel.Date, viewModel.Time)),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };

            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}