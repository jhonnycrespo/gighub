using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using GigHubApp.Core.Models;
using GigHubApp.Persistence;

namespace GigHubApp.Controllers.API
{
    [Authorize]
    public class GigsController : ApiController
    {
        private GigHubContext _context;

        public GigsController()
        {
            _context = new GigHubContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();

            // eager loading
            var gig = _context.Gigs
                .Include(g => g.Attendances.Select(a => a.Attendee))
                .Single(g => g.Id == id && g.ArtistId == userId);

            if (gig.IsCanceled)
                return NotFound();

            gig.Cancel();

            _context.SaveChanges();

            return Ok();
        }
    }
}
