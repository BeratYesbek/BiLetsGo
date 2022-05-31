using AutoMapper;
using Entity.Concretes;
using Entity.Concretes.Dto;

namespace WebAPI.AutoMapper.Profiles
{
    public class TicketProfiles : Profile
    {
        public TicketProfiles()
        {
            CreateMap<TicketCreateDto, Ticket>();
            CreateMap<TicketCreateDto, TicketFile>();

        }
    }
}
