using System.Collections.Generic;
using GigHubApp.Models;

namespace GigHubApp.Repositories
{
    public interface IAttendanceRepository
    {
        Attendance GetAttendance(int gigId, string userId);
        IEnumerable<Attendance> GetFutureAttendances(string userId);
    }
}