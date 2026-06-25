using Dsw2026Ej15.Domain.Interfaces;
using Dsw2026Ej15.Data;
using Dsw2026Ej15.Api.Middleware;
using Microsoft.EntityFrameworkCore;


namespace Dsw2026Ej15.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;DataBase=Dsw2026Ej15;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True";

            builder.Services.AddDbContext<Dsw2026Ej15DbContext>(options=> {
                options.UseSqlServer(connectionString);// indicamos donde esta la base de datos: cadena de conexion(depende del motor que utiliamos)
            });
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IPersistence, PersistenceEF>();
            builder.Services.AddHealthChecks();
            var app = builder.Build();

            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseAuthorization();


            app.MapControllers();
            app.MapHealthChecks("/health-check");
            app.Run();
        }
    }
}
