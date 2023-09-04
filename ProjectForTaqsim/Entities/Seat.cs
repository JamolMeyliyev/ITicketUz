using System.Text.Json.Serialization;

namespace ProjectForTaqsim.Entities;

public class Seat:BaseEntity
{
    public long EventId { get; set; }
    [JsonIgnore]
    public Event? Event { get; set; }
    public long Row { get; set; }
    public long SeatInRow { get; set; }
    public bool IsBusy { get; set; } = true;
}
