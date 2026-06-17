using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Dsw2026Ej15.Domain.Entities;

namespace Dsw2026Ej15.Domain.Interfaces
{
    public interface IPersistence
    {
        public void AgregarDoctor(Doctor doctor);
        public void AgregarEspecialidad(Speciality especialidad);

        public void EliminarDoctor(Doctor doctor);
        public void EliminarEspecialidad(Speciality especialidad);

        public List<Doctor> GetDoctores();

        public List<Speciality> GetEspecialidades();

        public Doctor? GetDoctor(Guid id);

        public Speciality? GetSpeciality(Guid id);

        
    }
}
