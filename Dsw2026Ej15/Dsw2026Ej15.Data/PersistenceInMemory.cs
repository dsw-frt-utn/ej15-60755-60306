using System.Net.WebSockets;
using System.Text.Json;
using Dsw2026Ej15.Data.Dto;
using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Domain.Interfaces;

namespace Dsw2026Ej15.Data
{
    public class PersistenceInMemory : IPersistence
    {
        List<Doctor> _doctors = [];
        List<Speciality> _specialities = [];

        public PersistenceInMemory()
        {
            this.LoadSpecialities();
        }

        
        public void AddDoctor(Doctor doctor)
        {
            _doctors.Add(doctor);
        }

        public Doctor? GetDoctorActive(Guid id)
        {
            return _doctors.SingleOrDefault(d => d.Id == id && d.IsActive);
         }
    

        public void RemoveDoctor(Doctor doctor)
        {
            _doctors.Remove(doctor);
        }

        

        public List<Doctor> GetDoctorsActive()
        {
            return _doctors.Where(d=>d.IsActive).ToList();
        }



        public Speciality? GetSpeciality(Guid id)
        {
            return _specialities.SingleOrDefault(d => d.Id == id);
        }

        private void LoadSpecialities()
        {
            try
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sources", "specialities.json");
                var json = File.ReadAllText(path);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                var speciality = JsonSerializer.Deserialize<List<SpecialityDto>>(json, options);


                 _specialities = [.. speciality.Select(s => new Speciality(s.Name, s.Description, s.Id))];
            }
            catch (Exception e){ }
        }

        
    }
}