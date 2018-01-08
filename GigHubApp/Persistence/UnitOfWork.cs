using GigHubApp.Models;
using GigHubApp.Repositories;

namespace GigHubApp.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GigHubContext _context;

        public IGigRepository Gigs { get; private set; }
        public IAttendanceRepository Attendances { get; private set; }
        public IFollowingRepository Followings { get; private set; }
        public IGenreRepository Genres { get; private set; }

        public UnitOfWork(GigHubContext context)
        {
            _context = context;
            Gigs = new GigRepository(context);
            Attendances = new AttendanceRepository(context);
            Followings = new FollowingRepository(context);
            Genres = new GenreRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}