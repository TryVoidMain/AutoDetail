using AutoDetail.DAL.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace AutoDetail.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
