using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Dsw2026Ej15.Domain.Entities;

namespace Dsw2026Ej15.Domain.Interfaces
{
    public interface IPersistence
    {
        Task AddDoctor(Doctor doctor);

        Task<IEnumerable<Doctor>> GetAllDoctor();

        Task<Doctor?> GetDoctorById(Guid id);

        Task<Speciality?> GetSpecialityById(Guid id);

         Task UpdateDoctor(Doctor doctor);

        

  
    }
}
