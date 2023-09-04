using ProjectForTaqsim.Dtos.CreateDtos;
using ProjectForTaqsim.Entities;

namespace ProjectForTaqsim.Managers.IManager;

public interface IEventManager
{

    Task<List<Event>> Get(long palaceId);

    Task<Event> GetByEventWithSeats(long palaceId,long eventId);
    Task<Event> GetByEventWithTickets(long palaceId, long eventId);
    Task<Event> Create(long PalaceId,CreateEventDto dto);

}
