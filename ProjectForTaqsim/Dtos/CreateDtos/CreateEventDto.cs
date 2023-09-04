using ProjectForTaqsim.Entities;

namespace ProjectForTaqsim.Dtos.CreateDtos;

public class CreateEventDto
{
    public required string Name { get; set; }
   
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public long Price { get; set; }
   
}
