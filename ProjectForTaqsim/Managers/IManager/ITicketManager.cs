using ProjectForTaqsim.Dtos.CreateDtos;
using ProjectForTaqsim.Entities;
using ProjectForTaqsim.Filter;

namespace ProjectForTaqsim.Managers.IManager;

public interface ITicketManager
{

    Task<List<Ticket>> Get(long eventId);
    Task<Ticket> Create(long eventId,CreateTicketDto dto);
    Task Delete(long eventId,long ticketId,string secret);
}
