using System.Collections.Generic;
using GigHubApp.Core.Models;

namespace GigHubApp.Core.Repositories
{
    public interface IAttendanceRepository
    {
        Attendance GetAttendance(int gigId, string userId);
        IEnumerable<Attendance> GetFutureAttendances(string userId);
    }
}