using ProjectForTaqsim.Entities;
using ProjectForTaqsim.Filter;

namespace ProjectForTaqsim.Managers.IManager;

public interface ISeatManager
{
    ValueTask UpdateSeat(long eventId,Ticket ticket);
    Task<List<Seat>> AllNoBought(long eventId,SeadFilter filter);
}
