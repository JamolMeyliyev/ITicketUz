using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectForTaqsim.Dtos.CreateDtos;
using ProjectForTaqsim.Exceptions;
using ProjectForTaqsim.Managers.IManager;

namespace ProjectForTaqsim.Controllers
{
    [Route("api/events/{eventId}/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        readonly ITicketManager _manager;
        public TicketsController(ITicketManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(long eventId)
        {
            try
            {
                return Ok(await _manager.Get(eventId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(long eventId, [FromBody] CreateTicketDto createDto)
        {
            try
            {
                var result = await _manager.Create(eventId, createDto);
                return Created("", result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{ticketId}")]
        public async Task<IActionResult> Delete(long eventId,long ticketId,string secret)
        {
            try
            {
                await _manager.Delete(eventId, ticketId, secret);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
