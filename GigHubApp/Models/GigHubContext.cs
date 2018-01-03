using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace GigHubApp.Models
{
    public class GigHubContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public GigHubContext()
            : base("GigHubContext", throwIfV1Schema: false)
        {
        }

        public static GigHubContext Create()
        {
            return new GigHubContext();
        }
    }
}