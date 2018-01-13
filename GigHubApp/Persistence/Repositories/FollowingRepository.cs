using GigHubApp.Core.Models;
using GigHubApp.Core.Repositories;
using System.Linq;

namespace GigHubApp.Persistence.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private GigHubContext _context;

        public FollowingRepository(GigHubContext context)
        {
            _context = context;
        }

        public void Add(Following following)
        {
            _context.Followings.Add(following);
        }

        public Following GetFollowing(string followerId, string followeeId)
        {
            return _context.Followings
                .SingleOrDefault(f => f.FolloweeId == followeeId && f.FollowerId == followerId);
        }

        public void Remove(Following following)
        {
            _context.Followings.Remove(following);
        }
    }
}