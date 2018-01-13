using System.Data.Entity.ModelConfiguration;
using GigHubApp.Core.Models;

namespace GigHubApp.Persistence.EntityConfigurations
{
    public class NotificationConfiguration : EntityTypeConfiguration<Notification>
    {
        public NotificationConfiguration()
        {
            HasRequired(n => n.Gig);
        }
    }
}