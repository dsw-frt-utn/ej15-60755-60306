using Dsw2026Ej15.Domain;
using System.Text.Json;

namespace Dsw2026Ej15.Data
{
    public class PersistenceInMemory : IPersistence
    {
        List<Doctor> Doctores;
        List<Speciality> Especialidades;

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

        public Speciality? GetEspecialidad(Guid id)
        {
            return Especialidades.Find(d => d.Id == id);
        }

        //JSON

        private List<Speciality> LoadSpecialities()
        {
            var path = "specialities.json";

            if(!File.Exists(path))
            {
                return new List<Speciality>();
            }

            var json = File.ReadAllText(path);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var resultado = JsonSerializer.Deserialize<List<Speciality>>(json, options);

            return resultado ?? new List<Speciality>();
        }

    }
}
