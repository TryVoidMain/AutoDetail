using AutoDetail.CQRS;
using AutoDetail.DAL.Abstractions;
using AutoDetail.DAL.DatabaseContext;
using AutoDetail.DAL.Interfaces;
using MediatorLight.Registration;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace AutoDetail.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .WriteTo.Console()
                .CreateLogger();

            builder.Host.UseSerilog();

            // Add services to the container.
            var services = builder.Services;
            var configuration = builder.Configuration;

            configuration
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            services.AddDbContext<AutoDetailDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("AutoDetailDb"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddMediatorLight(CQRSAssemblyInfo.Value);
            services.AddControllers();
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
