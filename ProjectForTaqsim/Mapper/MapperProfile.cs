using AutoMapper;
using ProjectForTaqsim.Dtos.CreateDtos;
using ProjectForTaqsim.Entities;

namespace ProjectForTaqsim.Mapper;

public class MapperProfile:Profile
{
   public MapperProfile()
    {
        CreateMap<Palace,CreatePalaceDto>().ReverseMap();
        CreateMap<Event, CreateEventDto>().ReverseMap();
        CreateMap<Ticket, CreateTicketDto>().ReverseMap();
    }
}
