using Dsw2026Ej15.Domain.Interfaces;
using Dsw2026Ej15.Data;
using Microsoft.EntityFrameworkCore;
using Dsw2026Ej15.Api.Extensions;
using Dsw2026Ej15.Aplication.Interfaces;
using Dsw2026Ej15.Aplication.Services;


namespace Dsw2026Ej15.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnections");

            builder.Services.AddDbContext<Dsw2026Ej15DbContext>(options=> {
                options.UseSqlServer(connectionString);
            });
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IPersistence, PersistenceEF>();
            builder.Services.AddScoped<IDoctorManagmentService,DoctorManagmentService>();
            builder.Services.AddHealthChecks();
            

            var app = builder.Build();

            app.UseMiddleware<ExceptionMiddleware>();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
  
            app.MapControllers();
            app.MapHealthChecks("/health-check");

            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetService<Dsw2026Ej15DbContext>();
            context.SeedSpecialitiesFromJson(@"specialities.json");
            app.Run();


           
        }
    }
}
