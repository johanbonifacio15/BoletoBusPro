using BoletoBusPro.Module.Application.Interfaces;
using BoletoBusPro.Module.Application.Dtos.AsientoDto;
using Microsoft.AspNetCore.Mvc;

namespace BoletoBusPro.Module.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsientoController : ControllerBase
    {
        private readonly IAsientoService asientoService;

        public AsientoController(IAsientoService asientoService)
        {
            this.asientoService = asientoService;
        }

        // GET: api/Asiento
        [HttpGet("GetAsientos")]
        public IActionResult Get()
        {
            var result = this.asientoService.GetAsientos();
            if (!result.Success)
                return BadRequest(result.Message);
            else
                return Ok(result.Data);
        }

        // GET: api/Asiento/5
        [HttpGet("GetAsiento")]
        public IActionResult Get(int id)
        {
            var result = this.asientoService.GetAsiento(id);
            if (!result.Success)
                return NotFound(result.Message);
            else
                return Ok(result.Data);
        }

        // POST: api/Asiento
        [HttpPost("SaveAsiento")]
        public IActionResult Post([FromBody] AsientoDtoAdd dtoAdd)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = this.asientoService.SaveAsiento(dtoAdd);
            if (!result.Success)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(Get), new { id = result.Data.Id }, result.Data);
        }

        [HttpPost("UpdateAsiento")]
        public IActionResult Put([FromBody] AsientoDtoUpdate dtoUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = this.asientoService.UpdateAsiento(dtoUpdate);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }

        // DELETE: api/Asiento
        [HttpDelete("RemoveAsiento")]
        public IActionResult Delete([FromBody] AsientoDtoRemove dtoRemove)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = this.asientoService.RemoveAsiento(dtoRemove);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }
    }
}





