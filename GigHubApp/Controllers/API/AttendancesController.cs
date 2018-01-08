using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using GigHubApp.Core.DTOs;
using GigHubApp.Core.Models;
using GigHubApp.Persistence;

namespace GigHubApp.Controllers.API
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private GigHubContext _context;

        public AttendancesController()
        {
            _context = new GigHubContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDTO dto)
        {
            var userId = User.Identity.GetUserId();
            var exists = _context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId);

            if (exists)
                return BadRequest("The attendance already exists");

            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteAttendance(int id)
        {
            var userId = User.Identity.GetUserId();

            var attendance = _context.Attendances
                .SingleOrDefault(a => a.AttendeeId == userId && a.GigId == id);

            if (attendance == null)
                return NotFound();

            _context.Attendances.Remove(attendance);
            _context.SaveChanges();

            return Ok(id);
        }
    }
}
