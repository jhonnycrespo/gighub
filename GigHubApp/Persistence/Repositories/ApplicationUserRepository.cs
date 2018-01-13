using GigHubApp.Core.Models;
using GigHubApp.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GigHubApp.Persistence.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly GigHubContext _context;

        public ApplicationUserRepository(GigHubContext context)
        {
            _context = context;
        }

        public IEnumerable<ApplicationUser> GetArtistsFollowedBy(string userId)
        {
            return _context.Followings
                .Where(f => f.FollowerId == userId)
                .Select(f => f.Followee)
                .ToList();
        }
    }
}