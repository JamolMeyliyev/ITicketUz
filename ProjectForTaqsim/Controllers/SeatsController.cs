using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectForTaqsim.Filter;
using ProjectForTaqsim.Managers.IManager;

namespace ProjectForTaqsim.Controllers;

[Route("api/events/{eventId}/[controller]")]
[ApiController]
public class SeatsController : ControllerBase
{
    readonly ISeatManager _manager;
    public SeatsController(ISeatManager manager)
    {
        _manager = manager;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllNoBought(long eventId,[FromQuery] SeadFilter filter )
    {
        try
        {
            return Ok(await _manager.AllNoBought(eventId,filter));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
