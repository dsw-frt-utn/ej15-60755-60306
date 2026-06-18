using Dsw2026Ej15.Data;
using Microsoft.AspNetCore.Mvc;
using Dsw2026Ej15.Api.Models;
using Dsw2026Ej15.Domain.Interfaces;
using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Api.Exceptions;

namespace Dsw2026Ej15.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {

        private readonly IPersistence _persistence;

        public DoctorsController(IPersistence i) {
            _persistence = i;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctors([FromBody] DoctorModel.Request request) { 
            
            if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.LicenseNumber)) { 
                throw new ValidationException("Nombre y Matrícula son requeridos.");//BadRequest("Escribi bien,Nombre y Matriculas son  requeridos");
            }
            var speciality = _persistence.GetSpeciality(request.SpecialityId);

            if (speciality == null) {
                throw new ValidationException("La especialidad no existe"); //BadRequest("La especialidad no existe");
            }
            Doctor doctor = new Doctor(request.Name, request.LicenseNumber, speciality);
            
            _persistence.AddDoctor(doctor);
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors() {
            var doctors = _persistence.GetDoctorsActive();

            return Ok(doctors);
        
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorActive(Guid id)
        {
            var doctor = _persistence.GetDoctorActive(id);
            if (doctor == null)
            {
                return NotFound("Medico no esta activo o no se encuentra");
            }
            else
            {
                var response = new DoctorModel.Response(
                    doctor.Name,
                    doctor.LicenseNumber,
                    doctor.Speciality?.Name
                    );
                return Ok(response);
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(Guid id) {
            var doctor = _persistence.GetDoctorActive(id);

            if (doctor == null) {
                return NotFound("El doctor no se encuentra activo o no esta guardado");
            }
            else
            {
                doctor.Desactive();
                return NoContent();
            }
        }
        
        // hacer los otros metodos del endpoint


    }
}
