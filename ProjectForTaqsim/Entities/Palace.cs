namespace ProjectForTaqsim.Entities;

public class Palace:BaseEntity
{
    public required string Name { get; set; }
    public required string Address { get; set; }
    public long Capacity { get; set; }
    public long Row { get; set; }
    public long SeatInRow { get; set; }
    public List<Event>? Events { get; set; }
}
