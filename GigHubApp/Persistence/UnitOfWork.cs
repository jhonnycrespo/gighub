﻿using GigHubApp.Models;
using GigHubApp.Repositories;

namespace GigHubApp.Persistence
{
    public class UnitOfWork
    {
        private readonly GigHubContext _context;

        public GigRepository Gigs { get; private set; }
        public AttendanceRepository Attendances { get; private set; }
        public FollowingRepository Followings { get; private set; }
        public GenreRepository Genres { get; private set; }

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