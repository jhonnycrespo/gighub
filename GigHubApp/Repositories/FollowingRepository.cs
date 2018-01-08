using GigHubApp.Models;
using System.Linq;

namespace GigHubApp.Repositories
{
    public class FollowingRepository
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