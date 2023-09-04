using Microsoft.EntityFrameworkCore;
using ProjectForTaqsim.Entities;

namespace ProjectForTaqsim.Context;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Palace> Palaces { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Seat> Seats { get; set; }
}


