using System.Text.Json.Serialization;

namespace ProjectForTaqsim.Entities;

public class Event:BaseEntity
{
    public required string Name { get; set; }
    public long PalaceId { get; set; }

    [JsonIgnore]
    public Palace? Palace { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public long Price { get; set; }
    public List<Ticket>? Tickets { get; set; }
    public List<Seat>? Seats { get; set; }



}
