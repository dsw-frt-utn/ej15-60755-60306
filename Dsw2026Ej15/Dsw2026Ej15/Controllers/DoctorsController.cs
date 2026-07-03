using Dsw2026Ej15.Application.Interfaces;
using Dsw2026Ej15.Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Dsw2026Ej15.Controllers
{
    [ApiController]

    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _services;

        public DoctorsController(IDoctorService services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctors([FromBody] DoctorModel.Request request)
        {
            await _services.CreateDoctors(request);
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctor()
        {
            var response = await _services.GetAllDoctors();
            return Ok(response);  // Ok con lista vacía es correcto, no hace falta NoContent acá
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctor([FromRoute] Guid id)
        {
            var response = await _services.GetDoctor(id);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor([FromRoute] Guid id)
        {
            await _services.DeleteDoctor(id);
            return NoContent();
        }
    }
}