using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectForTaqsim.Dtos.CreateDtos;
using ProjectForTaqsim.Managers.IManager;

namespace ProjectForTaqsim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalacesController : ControllerBase
    {
        readonly IPalaceManager _manager;
        public PalacesController(IPalaceManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePalaceDto createDto)
        {
            try
            {
                var result = await _manager.Create(createDto);
                return Created("", result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
