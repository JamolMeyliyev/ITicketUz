using ProjectForTaqsim.Entities;

namespace ProjectForTaqsim.Dtos.CreateDtos;

public class CreateTicketDto
{
    public required string FullName { get; set; }
    public long Row { get; set; }
    public long Seat { get; set; }
    public required string Secret { get; set; }
}
