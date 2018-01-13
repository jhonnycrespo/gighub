using GigHubApp.Core;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace GigHubApp.Controllers.API
{
    [Authorize]
    public class GigsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        //private GigHubContext _context;

        public GigsController(IUnitOfWork unitOfWork)
        {
            //_context = new GigHubContext();
            _unitOfWork = unitOfWork;
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();

            // eager loading
            //var gig = _context.Gigs
            //    .Include(g => g.Attendances.Select(a => a.Attendee))
            //    .Single(g => g.Id == id && g.ArtistId == userId);

            var gig = _unitOfWork.Gigs.GetGigWithAttendees(id);

            //TODO: Bug - if gig == null

            if (gig.IsCanceled)
                return NotFound();

            gig.Cancel();

            //_context.SaveChanges();
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
