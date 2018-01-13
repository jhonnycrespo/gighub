using GigHubApp.Core;
using GigHubApp.Core.DTOs;
using GigHubApp.Core.Models;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace GigHubApp.Controllers.API
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        //private GigHubContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public AttendancesController(IUnitOfWork unitOfWork)
        {
            //_context = new GigHubContext();
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDTO dto)
        {
            var userId = User.Identity.GetUserId();
            //var exists = _context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId);
            var attendance = _unitOfWork.Attendances.GetAttendance(dto.GigId, userId);

            if (attendance != null)
                return BadRequest("The attendance already exists");

            attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };

            //_context.Attendances.Add(attendance);
            //_context.SaveChanges();
            _unitOfWork.Attendances.Add(attendance);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteAttendance(int id)
        {
            var userId = User.Identity.GetUserId();

            //var attendance = _context.Attendances
            //    .SingleOrDefault(a => a.AttendeeId == userId && a.GigId == id);

            var attendance = _unitOfWork.Attendances.GetAttendance(id, userId);

            if (attendance == null)
                return NotFound();

            //_context.Attendances.Remove(attendance);
            //_context.SaveChanges();
            _unitOfWork.Attendances.Remove(attendance);
            _unitOfWork.Complete();

            return Ok(id);
        }
    }
}
