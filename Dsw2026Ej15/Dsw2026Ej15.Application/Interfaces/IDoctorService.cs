using Dsw2026Ej15.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Application.Interfaces
{
    public interface IDoctorService
    {
            public Task<IEnumerable<DoctorModel.Response>> GetAllDoctors();
            public Task<DoctorModel.Response> GetDoctor(Guid id);

            public Task DeleteDoctor(Guid id);

            public Task CreateDoctors(DoctorModel.Request request);

        
    }
}
