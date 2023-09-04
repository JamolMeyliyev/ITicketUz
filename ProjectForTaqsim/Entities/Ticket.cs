using System.Text.Json.Serialization;

namespace ProjectForTaqsim.Entities;

public class Ticket:BaseEntity
{
    public required string FullName { get; set; }
    public long EventId { get; set; }

    [JsonIgnore]
    public Event? Event { get; set; }
    public long Row { get; set; }
    public long Seat { get; set; }
    public required string Secret { get; set; }
}
