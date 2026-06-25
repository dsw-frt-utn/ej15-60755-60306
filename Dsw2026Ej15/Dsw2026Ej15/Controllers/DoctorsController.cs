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

        public DoctorsController(IPersistence p) {
            _persistence = p;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctors([FromBody] DoctorModel.Request request) {

            if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.LicenseNumber)) {
                throw new ValidationException("Nombre y Matrícula son requeridos.");
            }
            var speciality = await _persistence.GetSpecialityById(request.SpecialityId);

            if (speciality == null) throw new ValidationException("La especialidad no existe");

            Doctor doctor = new Doctor(request.Name, request.LicenseNumber, speciality);

            await _persistence.AddDoctor(doctor);
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors() {
            var doctors = await _persistence.GetAllDoctor();

            var response = doctors.Select(d => new DoctorModel.Response(d.Name, d.LicenseNumber, d.Speciality?.Name));
            return Ok(response);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorActive([FromRoute] Guid id)
        {
            var doctor = await _persistence.GetDoctorById(id);
            if (doctor == null) throw new EntityNotFoundException("Medico no encontrado");
            else
            {
                var response = new DoctorModel.Response(
                    doctor.Name,
                    doctor.LicenseNumber,
                    doctor.Speciality.Name
                    );
                return Ok(response);
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor([FromRoute] Guid id) {
            await _persistence.DeleteDoctor(id);
            return NoContent();
        }

        

    }
}
