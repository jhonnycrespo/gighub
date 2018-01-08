using System.Linq;
using GigHubApp.Core.Models;
using GigHubApp.Core.Repositories;

namespace GigHubApp.Persistence.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private GigHubContext _context;

        public FollowingRepository(GigHubContext context)
        {
            _context = context;
        }

        public Following GetFollowing(string followerId, string followeeId)
        {
            return _context.Followings
                .SingleOrDefault(f => f.FolloweeId == followeeId && f.FollowerId == followerId);
        }
    }
}