using GigHubApp.Core.Models;
using System.Collections.Generic;

namespace GigHubApp.Core.Repositories
{
    public interface IApplicationUserRepository
    {
        IEnumerable<ApplicationUser> GetArtistsFollowedBy(string userId);
    }
}