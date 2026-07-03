using Dsw2026Ej15.Data.Dto;
using Dsw2026Ej15.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Dsw2026Ej15.Data.Extensions
{
    public static class DbContextExtensions
    {
        public static void SeedSpecialitiesFromJson(this AppDbContext context, string dataSource)
        {
            if (context.Set<Speciality>().Any()) return;

            var json = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Sources", dataSource));
            var entities = JsonSerializer.Deserialize<List<SpecialityDto>>(json, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            }) ?? [];
            var specialities = entities.Select(s => new Speciality(s.Name, s.Description, s.Id));
            context.Set<Speciality>().AddRange(specialities);
            context.SaveChanges();


        }
    }
}
