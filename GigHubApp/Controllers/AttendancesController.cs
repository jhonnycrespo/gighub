﻿using GigHubApp.DTOs;
using GigHubApp.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHubApp.Controllers
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
    }
}