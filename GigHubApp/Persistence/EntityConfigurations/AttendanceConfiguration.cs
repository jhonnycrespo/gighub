using System.Data.Entity.ModelConfiguration;
using GigHubApp.Core.Models;

namespace GigHubApp.Persistence.EntityConfigurations
{
    public class AttendanceConfiguration : EntityTypeConfiguration<Attendance>
    {
        public AttendanceConfiguration()
        {
            HasKey(a => new { a.GigId, a.AttendeeId });
        }
    }
}