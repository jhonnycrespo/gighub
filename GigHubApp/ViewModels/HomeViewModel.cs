using GigHubApp.Models;
using System.Collections.Generic;

namespace GigHubApp.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Gig> UpcomingGigs { get; set; }
        public bool ShowActions { get; set; }
    }
}