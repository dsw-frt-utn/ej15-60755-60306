using Dsw2026Ej15.Aplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Aplication.Interfaces
{
    public interface IDoctorManagmentService
    {
        public  Task<IEnumerable<DoctorModel.Response>> GetAllDoctors();
        public Task<DoctorModel.Response> GetDoctor(Guid id);

        public  Task DeleteDoctor(Guid id);

        public Task CreateDoctors(DoctorModel.Request request);

    }
}
