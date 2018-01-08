using System.Collections.Generic;
using System.Linq;
using GigHubApp.Core.Models;
using GigHubApp.Core.Repositories;

namespace GigHubApp.Persistence.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly GigHubContext _context;

        public GenreRepository(GigHubContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }
    }
}