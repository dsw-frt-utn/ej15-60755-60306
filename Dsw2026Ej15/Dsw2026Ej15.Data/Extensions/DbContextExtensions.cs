using Dsw2026Ej15.Data;
using Dsw2026Ej15.Domain.Entities;
using System.Text.Json;
using Dsw2026Ej15.Data.Dto;

namespace Dsw2026Ej15.Data.Extensions
{
    public static class DbContextExtensions
    {
        public static void SeedSpecialitiesFromJson(this Dsw2026Ej15DbContext context,string dataSource)
        {
            if (context.Set<Speciality>().Any()) return;

            var json = File.ReadAllText(Path.Combine(AppContext.BaseDirectory,"Sources",dataSource));
            var entities = JsonSerializer.Deserialize<List<SpecialityDto>>(json,new JsonSerializerOptions() { 
                PropertyNameCaseInsensitive=true
            })?? [];
            var specialities = entities.Select(s=> new Speciality(s.Name,s.Description,s.Id));
            context.Set<Speciality>().AddRange(specialities);
            context.SaveChanges();


        }
    }
}
