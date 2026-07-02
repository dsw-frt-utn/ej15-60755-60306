using Dsw2026Ej15.Aplication.Models;
using Dsw2026Ej15.Data;
using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Domain.Interfaces;
using Dsw2026Ej15.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Dsw2026Ej15.Aplication.Interfaces;
namespace Dsw2026Ej15.Aplication.Services
{
    public class DoctorManagmentService:IDoctorManagmentService
    {
        private IPersistence _persistence;
        public DoctorManagmentService(IPersistence persistence) {
            _persistence = persistence;        
        }

        public async Task<IEnumerable<DoctorModel.Response>> GetAllDoctors() {
            var doctors = await  _persistence.GetAllDoctor();
            var response = doctors.Select(d => new DoctorModel.Response(d.Name, d.LicenseNumber, d.Speciality?.Name));
            return response;

        }

        public async Task<DoctorModel.Response> GetDoctor(Guid id)
        {
            var doctor = await _persistence.GetDoctorById(id);
            if (doctor == null) throw new EntityNotFoundException("Medico no encontrado");
            
                var response = new DoctorModel.Response(
                    doctor.Name,
                    doctor.LicenseNumber,
                    doctor.Speciality.Name
                    );

            return response;
        }


        public async Task DeleteDoctor(Guid id) {
            var doctor = await _persistence.GetDoctorById(id);
            if (doctor != null)
            {
                doctor.Desactive();
                await _persistence.UpdateDoctor(doctor);
            }
            else
            {
                throw new EntityNotFoundException("Medico no encontrado");
            }

        }
        public async Task CreateDoctors(DoctorModel.Request request) {

            if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.LicenseNumber))
            {
                throw new ValidationException("Nombre y Matrícula son requeridos.");
            }
            var speciality = await _persistence.GetSpecialityById(request.SpecialityId);

            if (speciality == null) throw new ValidationException("La especialidad no existe");

            Doctor doctor = new Doctor(request.Name, request.LicenseNumber, speciality);

            await _persistence.AddDoctor(doctor);

        }



    }
}
