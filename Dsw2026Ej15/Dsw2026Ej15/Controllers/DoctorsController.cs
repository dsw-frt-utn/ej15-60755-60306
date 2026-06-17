using Dsw2026Ej15.Data;
using Microsoft.AspNetCore.Mvc;
using Dsw2026Ej15.Domain.Interfaces;
using Dsw2026Ej15.Api.Models;

namespace Dsw2026Ej15.Controllers
{
    [ApiController]
    [Route("[controller]")]// corregir la ruta para que sea sin mayuscula : doctor
    public class DoctorsController : ControllerBase
    {

        private readonly IPersistence _persistence;

        public DoctorsController(IPersistence i) {
            _persistence = i;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctors([FromBody]DoctorsModel.Request request) { // From body recupera los datos del body
            // requerido no venga nulo, vacio, o espacio en blanco
            if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.LicenseNumber)) return BadRequest("Escribi bien,Nombre y Matriculas son  requeridos");
            var speciality = _persistence.GetSpeciality(request.SpecialityId);
            if (speciality == null) {
                return BadRequest("La especialidad no existe");
            }
            // implementar la logica de agregar  el doctor a la clase de persistencia
            
            return Created();
        }
        // hacer los otros metodos del endpoint
    
    
    }
}
