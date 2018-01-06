using GigHubApp.Models;
using System;

namespace GigHubApp.DTOs
{
    public class NotificationDTO
    {
        public DateTime DateTime { get; set; }
        public NotificationType Type { get; set; }
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalVenue { get; set; }
        public GigDTO Gig { get; set; }
    }
}