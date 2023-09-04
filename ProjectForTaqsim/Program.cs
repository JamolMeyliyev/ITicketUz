using Microsoft.EntityFrameworkCore;

using ProjectForTaqsim.Context;
using ProjectForTaqsim.Managers.IManager;
using ProjectForTaqsim.Managers.Manager;
using ProjectForTaqsim.Mapper;
using ProjectForTaqsim.Ropisitories.IRepository;
using ProjectForTaqsim.Ropisitories.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped<IPalaceManager, PalaceManager>();
builder.Services.AddScoped<IEventManager, EventManager>();
builder.Services.AddScoped<ITicketManager, TicketManager>();
builder.Services.AddScoped<ISeatManager, SeatManager>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options
            .UseNpgsql(builder.Configuration.GetConnectionString("Connection"));
            //.UseInMemoryDatabase("db");
            
});

builder.Services.AddAutoMapper(typeof(MapperProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
