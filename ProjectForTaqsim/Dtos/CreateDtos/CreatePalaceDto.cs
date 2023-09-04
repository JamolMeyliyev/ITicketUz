using ProjectForTaqsim.Entities;

namespace ProjectForTaqsim.Dtos.CreateDtos;

public class CreatePalaceDto
{
    public required string Name { get; set; }
    public required string Address { get; set; }
    public long Capacity { get; set; }
    public long Row { get; set; }
    public long SeatInRow { get; set; }
    
}
