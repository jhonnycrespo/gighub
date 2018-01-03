using GigHubApp.Models;
using GigHubApp.ViewModels;
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

        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }
    }
}