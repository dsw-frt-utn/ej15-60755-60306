using Dsw2026Ej15.Domain.Interfaces;
using Dsw2026Ej15.Data;
using Microsoft.EntityFrameworkCore;
using Dsw2026Ej15.Aplication.Interfaces;
using Dsw2026Ej15.Aplication.Services;
using Dsw2026Ej15.Api.Configurations;


namespace Dsw2026Ej15.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddApplicationPersistence(builder.Configuration);
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

            app.LoadSpecialityData();
            app.Run();


           
        }
    }
}
