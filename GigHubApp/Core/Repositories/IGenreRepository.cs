using System.Collections.Generic;
using GigHubApp.Core.Models;

namespace GigHubApp.Core.Repositories
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetGenres();
    }
}