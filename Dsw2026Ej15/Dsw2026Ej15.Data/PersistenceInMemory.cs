using System.Net.WebSockets;
using System.Text.Json;
using Dsw2026Ej15.Data.Dto;
using Dsw2026Ej15.Domain.Entities;
using Dsw2026Ej15.Domain.Interfaces;

namespace Dsw2026Ej15.Data
{
    // Cambiar el nombre de las clases en ingles
    public class PersistenceInMemory : IPersistence
    {
        List<Doctor> Doctores = [];
        List<Speciality> Especialidades = [];

        public PersistenceInMemory() {
            this.LoadSpecialities();
        }
        // MÉTODOS
        public void AgregarDoctor(Doctor doctor)
        {
            Doctores.Add(doctor);
        }

        public void AgregarEspecialidad(Speciality especialidad)
        {
            Especialidades.Add(especialidad);
        }

        public void EliminarDoctor(Doctor doctor)
        {
            Doctores.Remove(doctor);
        }

        public void EliminarEspecialidad(Speciality especialidad)
        {
            Especialidades.Remove(especialidad);
        }

        public List<Doctor> GetDoctores()
        {
            return Doctores;
        }

        public List<Speciality> GetEspecialidades()
        {
            return Especialidades;
        }

        public Doctor? GetDoctor(Guid id)
        {
            return Doctores.Find(d => d.Id == id);
        }

        public Speciality? GetSpeciality(Guid id)
        {
            return Especialidades.SingleOrDefault(d => d.Id == id);
        }

        //JSON

        
        private List<Speciality> LoadSpecialities()
        {
            // buscar la ruta del archivo
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sources", "specialities.json");
            var json = File.ReadAllText(path);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var speciality = JsonSerializer.Deserialize<List<SpecialityDto>>(json, options);

           
            List<Speciality> _speciality = [.. speciality.Select(s => new Speciality(s.Name, s.Description, s.Id))];

            return _speciality; 
        }

    }
}
