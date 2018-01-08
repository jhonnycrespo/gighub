using GigHubApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GigHubApp.Repositories
{
    public class AttendanceRepository
    {
        private readonly GigHubContext _context;

        public AttendanceRepository(GigHubContext context)
        {
            _context = context;
        }

        public IEnumerable<Attendance> GetFutureAttendances(string userId)
        {
            return _context.Attendances
                .Where(a => a.AttendeeId == userId && a.Gig.DateTime > DateTime.Now)
                .ToList();
        }

        public Attendance GetAttendance(int gigId, string userId)
        {
            return _context.Attendances
                .SingleOrDefault(a => a.GigId == gigId && a.AttendeeId == userId);
        }
    }
}