using GigHubApp.Core.Models;

namespace GigHubApp.Core.Repositories
{
    public interface IFollowingRepository
    {
        Following GetFollowing(string followerId, string followeeId);
    }
}