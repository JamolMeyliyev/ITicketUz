using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProjectForTaqsim.Dtos.CreateDtos;
using ProjectForTaqsim.Managers.IManager;

namespace ProjectForTaqsim.Controllers
{
    [Route("api/palaces/{palaceId}/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        
        readonly IEventManager _manager;
        public EventsController(IEventManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(long palaceId)
        {
            try
            {
                return Ok(await _manager.Get(palaceId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(long palaceId,[FromBody] CreateEventDto createDto)
        {
            try
            {
                var result = await _manager.Create(palaceId,createDto);
                return Created("", result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[Route("withSeats")]
        //[HttpGet("{eventId")]
        //public async Task<IActionResult> GetEventWithSeats(long palaceId, long eventId)
        //{
        //    try
        //    {
        //        return Ok( await _manager.GetByEventWithSeats(palaceId,eventId));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[Route("withTickets")]
        [HttpGet("{eventId}")]
        public async Task<IActionResult> GetEventWithTickets(long palaceId, long eventId)
        {
            try
            {
                return Ok(await _manager.GetByEventWithTickets(palaceId, eventId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
    
   
}

