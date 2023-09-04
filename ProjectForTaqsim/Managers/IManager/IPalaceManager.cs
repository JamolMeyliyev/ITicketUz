using ProjectForTaqsim.Dtos.CreateDtos;
using ProjectForTaqsim.Entities;

namespace ProjectForTaqsim.Managers.IManager;

public interface IPalaceManager
{
    Task<List<Palace>> Get();
    Task<Palace> Create(CreatePalaceDto dto);
}
