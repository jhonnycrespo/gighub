using System.Collections.Generic;
using GigHubApp.Models;

namespace GigHubApp.Repositories
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetGenres();
    }
}