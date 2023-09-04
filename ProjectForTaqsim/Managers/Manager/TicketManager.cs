using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectForTaqsim.Dtos.CreateDtos;
using ProjectForTaqsim.Entities;
using ProjectForTaqsim.Exceptions;
using ProjectForTaqsim.Filter;
using ProjectForTaqsim.Managers.IManager;
using ProjectForTaqsim.Ropisitories.IRepository;

namespace ProjectForTaqsim.Managers.Manager;

public class TicketManager : ITicketManager
{
    private readonly IRepository<Ticket> _repos;
    private readonly ISeatManager _seatManager;
    private readonly IMapper _mapper;
    public TicketManager(IRepository<Ticket> repos, IMapper mapper, ISeatManager seatManager)
    {
        _repos = repos;
        _mapper = mapper;
        _seatManager = seatManager;
    }

    public async Task<Ticket> Create(long eventId, CreateTicketDto dto)
    {
        var entity = _mapper.Map<Ticket>(dto);
        entity.EventId = eventId;
        await _seatManager.UpdateSeat(eventId, entity);
        return await _repos.CreateAsync(entity);

    }

    public async Task Delete(long eventId, long ticketId, string secret)
    {

        var entity = await _repos.GetASync( b => b.Id == ticketId && b.Secret == secret);
        if(entity == null)
        {
            throw new NotFoundException("ticket");
        }
        
        await _seatManager.UpdateSeat(eventId, entity);
        await _repos.DeleteAsync(entity);
    }

    public async Task<List<Ticket>> Get(long eventId)
    { 

        return await _repos.AllAsync(p => p.EventId == eventId).ToListAsync();
    }
}
