using GigHubApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace GigHubApp.Repositories
{
    public class GenreRepository
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