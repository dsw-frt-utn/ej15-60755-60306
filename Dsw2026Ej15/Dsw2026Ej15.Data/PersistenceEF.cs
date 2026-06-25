using Dsw2026Ej15.Api.Exceptions;
using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
namespace Dsw2026Ej15.Data
{
    
    public class PersistenceEF : IPersistence
    {

        private readonly Dsw2026Ej15DbContext _context;

        public PersistenceEF(Dsw2026Ej15DbContext contexto) {
            _context = contexto;
        }
        public async Task AddDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctor()
        {
            return await _context.Doctors.AsNoTracking().Where(d=>d.IsActive).ToListAsync();
        }

        public async Task<Doctor?> GetDoctorById(Guid id)
        {
            return await _context.Doctors.AsNoTracking().FirstOrDefaultAsync(d=>d.IsActive && d.Id==id);
        }

        public async Task<Speciality?> GetSpecialityById(Guid id)
        {
            return await  _context.Specialities.AsNoTracking().FirstOrDefaultAsync(s =>s.Id == id);
        }

      
        public async Task UpdateDoctor(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDoctor(Guid id)
        {
            var doctor =await  this.GetDoctorById(id);
            if (doctor != null)
            {
                doctor.Desactive();
                await UpdateDoctor(doctor);
            }
            else {
                throw new EntityNotFoundException("Medico no encontrado");
            }


        }
    }
}
