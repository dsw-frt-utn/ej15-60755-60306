using Dsw2026Ej15.Data.Extensions;
using Dsw2026Ej15.Data;
using Microsoft.EntityFrameworkCore;

namespace Dsw2026Ej15.Api.Configurations
{
    public static class PersistenceConfigurationExtensions
    {
        public static IServiceCollection AddApplicationPersistence(this IServiceCollection services, IConfiguration configuration) {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<Dsw2026Ej15DbContext>(options=> options.UseSqlServer(connectionString));
            return services;
        }
        public static IHost LoadSpecialityData(this IHost host) {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetService<Dsw2026Ej15DbContext>();
            context.SeedSpecialitiesFromJson(@"specialities.json");
            return host;
        }
    }
}
