using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectForTaqsim.Context;
using ProjectForTaqsim.Dtos.CreateDtos;
using ProjectForTaqsim.Entities;
using ProjectForTaqsim.Exceptions;
using ProjectForTaqsim.Managers.IManager;
using ProjectForTaqsim.Ropisitories.IRepository;

namespace ProjectForTaqsim.Managers.Manager;

public class EventManager:IEventManager
{
    private readonly IRepository<Event> _repos;
    private readonly IRepository<Palace> _palaceRepository;
    private readonly IRepository<Seat> _seatRepository;
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;
    public EventManager(
        IRepository<Event> repos,
        IMapper mapper,
        IRepository<Palace> palaceRepository, 
        IRepository<Seat> seatRepository,
        AppDbContext context)
    {
        _repos = repos;
        _mapper = mapper;
        _palaceRepository = palaceRepository;
        _seatRepository = seatRepository;
        _context = context;
    }

    public async Task<Event> Create(long PalaceId, CreateEventDto dto)
    {
        var palace = await _palaceRepository.GetASync(p => p.Id == PalaceId);
        if(palace == null)
        {
            throw new NotFoundException("Palace");
        }
        var entity = _mapper.Map<Event>(dto);
        entity.PalaceId= PalaceId;
        entity.Tickets = new List<Ticket>();
        var  eventSeats = new List<Seat>();

        var eventList =  _repos.AllAsync(e => true).ToList();
        foreach(var model in eventList)
        {
            if (model.StartDate.AddHours(-1) < dto.StartDate)
            {
                if (model.EndDate.AddHours(1) > dto.StartDate)
                {
                    throw new Exception("bu vaqtda joylar band");
                }
                if (model.EndDate.AddHours(1) > dto.EndDate)
                {
                    throw new Exception("bu vaqtda joylar band");
                }
            }
            if (model.StartDate.AddHours(-1) >= dto.StartDate)
            {
                if(model.StartDate.AddHours(-1) < dto.EndDate)
                {
                    throw new Exception("bu vaqtda joylar band");
                }
            }
          
        }
       var result = await _repos.CreateAsync(entity);

        for (int i = 1; i <= palace.Row; i++)
        {
            for(int j = 1; j <= palace.SeatInRow; j++)
            {
                var seat = new Seat();
                seat.Row = i;
                seat.SeatInRow = j;
                seat.IsBusy = true;
                seat.EventId = result.Id;
                var seatModel = await _seatRepository.CreateAsync(seat);
                eventSeats.Add(seatModel);
            }
        }
        a.Seats = eventSeats;
        return result ;
    }

    public async Task<List<Event>> Get(long palaceId)
    {
        return await _repos.AllAsync(p => p.PalaceId == palaceId).ToListAsync();
    }

    public async Task<Event> GetByEventWithSeats(long palaceId, long eventId)
    {

        var eventModel = await _context.Events.Include(e => e.Seats).FirstOrDefaultAsync(e => e.PalaceId == palaceId && e.Id == eventId);
        if(eventModel == null)
        {
            throw new NotFoundException("event");
        }
        return eventModel;
    }

    public async Task<Event> GetByEventWithTickets(long palaceId, long eventId)
    {
        var eventModel = await _context.Events.Include(e => e.Tickets).FirstOrDefaultAsync(e => e.PalaceId == palaceId && e.Id == eventId);
        if (eventModel == null)
        {
            throw new NotFoundException("event");
        }
        return eventModel;
    }
}
