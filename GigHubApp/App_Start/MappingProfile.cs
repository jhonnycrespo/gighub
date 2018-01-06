using AutoMapper;
using GigHubApp.DTOs;
using GigHubApp.Models;

namespace GigHubApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ApplicationUser, UserDTO>();
                cfg.CreateMap<Gig, GigDTO>();
                cfg.CreateMap<Notification, NotificationDTO>();
            });

            IMapper mapper = config.CreateMapper();
        }
    }
}