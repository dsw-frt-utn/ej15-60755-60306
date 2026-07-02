using Dsw2026Ej15.Data;
using Microsoft.AspNetCore.Mvc;
using Dsw2026Ej15.Aplication.Models;
using Dsw2026Ej15.Domain.Interfaces;
using Dsw2026Ej15.Aplication.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Dsw2026Ej15.Controllers
{
    [ApiController]
    
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {

        private readonly  IDoctorManagmentService _services;

        public DoctorsController(IDoctorManagmentService services) {
            _services = services;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctors([FromBody] DoctorModel.Request request) {
            await _services.CreateDoctors(request);
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctor() {
            var response=await _services.GetAllDoctors();

            if (response== null)   NoContent();
            return Ok(response);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctor([FromRoute] Guid id)
        {
            var response = await _services.GetDoctor(id);
            return Ok(response);
            

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor([FromRoute] Guid id) {
            await _services.DeleteDoctor(id);
            return NoContent();
        }

        

    }
}
