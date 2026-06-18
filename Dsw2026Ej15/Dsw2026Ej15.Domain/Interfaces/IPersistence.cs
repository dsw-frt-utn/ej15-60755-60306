using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Dsw2026Ej15.Domain.Entities;

namespace Dsw2026Ej15.Domain.Interfaces
{
    public interface IPersistence
    {
        void AddDoctor(Doctor doctor);
  

        void RemoveDoctor(Doctor doctor);
  

        List<Doctor> GetDoctorsActive();
        List<Speciality> GetSpecialities();

        Doctor? GetDoctorActive(Guid id);

        Speciality? GetSpeciality(Guid id);
    }
}
