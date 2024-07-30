using BoletoBusPro.Module.Application.Dtos.BusDto;
using BoletoBusPro.Module.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace BoletoBusPro.Module.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IBusService busService;

        public BusController(IBusService busService)
        {
            this.busService = busService;
        }

        // GET: api/Bus
        [HttpGet("GetBuses")]
        public IActionResult Get()
        {
            var result = this.busService.GetBuses();
            if (!result.Success)
                return BadRequest(result.Message);
            else
                return Ok(result.Data);
        }

        // GET: api/Bus/5
        [HttpGet("GetBus")]
        public IActionResult Get(int id)
        {
            var result = this.busService.GetBus(id);
            if (!result.Success)
                return NotFound(result.Message);
            else
                return Ok(result.Data);
        }

        // POST: api/Bus
        [HttpPost("SaveBuses")]
        public IActionResult Post([FromBody] BusDtoAdd dtoAdd)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = this.busService.SaveBus(dtoAdd);
            if (!result.Success)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(Get), new { id = result.Data.Id }, result.Data);
        }

        // POST: api/Bus/UpdateBuses
        [HttpPost("UpdateBuses")]
        public IActionResult Post([FromBody] BusDtoUpdate dtoUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = this.busService.UpdateBuses(dtoUpdate);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }


        // DELETE: api/Bus
        [HttpDelete("RemoveBuses")]
        public IActionResult Delete([FromBody] BusDtoRemove dtoRemove)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = this.busService.RemoveBuses(dtoRemove);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }
    }
}

