using Microsoft.EntityFrameworkCore;
using ProjectForTaqsim.Context;
using ProjectForTaqsim.Entities;
using ProjectForTaqsim.Exceptions;
using ProjectForTaqsim.Filter;
using ProjectForTaqsim.Managers.IManager;
using ProjectForTaqsim.Ropisitories.IRepository;

namespace ProjectForTaqsim.Managers.Manager;

public class SeatManager : ISeatManager
{
    private readonly AppDbContext _context;
    private readonly IRepository<Seat> _repository;
    public SeatManager(AppDbContext context,IRepository<Seat> repository)
    {
        _context = context;
        _repository = repository;
    }

    public async Task<List<Seat>> AllNoBought(long eventId,SeadFilter filter)
    {
        var seatQuery =  _context.Seats.AsQueryable();
        if (filter.FromRow != null)
        {
            seatQuery = seatQuery.Where(s => filter.FromRow <= s.Row && s.IsBusy == true); 
        }
        if (filter.ToRow != null)
        { 
            seatQuery = seatQuery.Where(s => filter.ToRow >= s.Row && s.IsBusy == true);
        }
        return seatQuery.ToList();
    }

    public async ValueTask UpdateSeat(long eventId,Ticket ticket)
    {
      var entity = await  _repository.GetASync(s => s.EventId == eventId && s.Row == ticket.Row && s.SeatInRow == ticket.Seat);
     

     if(entity == null)
        {
            throw new NotFoundException("event");
        }
        if(entity.IsBusy == true)
        {
            entity.IsBusy = false;
        }
        else
        {
            entity.IsBusy = true;
        }
        await _context.SaveChangesAsync();

    }

  

  
}
