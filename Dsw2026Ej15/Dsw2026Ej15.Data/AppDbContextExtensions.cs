using Dsw2026Ej15.Data.Dto;
using Dsw2026Ej15.Domain.Entities;
using System.Text.Json;

namespace Dsw2026Ej15.Data;

public static class AppDbContextExtensions
{
    public static void SeedworkSpecialities(this AppDbContext context, string jsonPath)
    {
        if (context.Specialities.Any()) return;

        if (!File.Exists(jsonPath)) return;

        var json = File.ReadAllText(jsonPath);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var datos = JsonSerializer.Deserialize<List<SpecialityDto>>(json, options);

        if (datos == null) return;

        foreach (var dto in datos)
            context.Specialities.Add(new Speciality(dto.Name, dto.Description));

        context.SaveChanges();
    }
}
