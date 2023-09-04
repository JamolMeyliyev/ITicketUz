using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectForTaqsim.Dtos.CreateDtos;
using ProjectForTaqsim.Entities;
using ProjectForTaqsim.Managers.IManager;
using ProjectForTaqsim.Ropisitories.IRepository;

namespace ProjectForTaqsim.Managers.Manager;

public class PalaceManager : IPalaceManager
{
    private readonly IRepository<Palace> _repos;
    private readonly IMapper _mapper;
    public PalaceManager(IRepository<Palace> repos,IMapper mapper)
    {
        _repos = repos;
        _mapper = mapper;
    }
    public async Task<Palace> Create(CreatePalaceDto dto)
    {
       var palace = _mapper.Map<Palace>(dto);
       
       return await _repos.CreateAsync(palace);
    }

    public async Task<List<Palace>> Get()
    {
        return await _repos.AllAsync(p => true).ToListAsync();
    }
}
