using AutoDetail.CQRS;
using AutoDetail.CQRS.Handlers.Queries;
using AutoDetail.DAL;
using AutoDetail.DAL.Abstractions;
using AutoDetail.DAL.DatabaseContext;
using AutoDetail.DAL.Interfaces;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatorLight.Implementation;
using MediatorLight.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace AutoDetail.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .WriteTo.Console()
                .CreateLogger();

            builder.Host.UseSerilog();

            builder.Host.ConfigureContainer<ContainerBuilder>(RegisterTypes);

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
            services.AddControllers();
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static void RegisterTypes(ContainerBuilder cb)
        {
            cb.RegisterAssemblyTypes(DALAssemblyInfo.Value);
            cb.RegisterAssemblyTypes(CQRSAssemblyInfo.Value);
            cb.RegisterType<Mediator>().As<IMediator>();

            cb.RegisterGeneric(typeof(GetEntityByIdQueryHandler<>))
                .As(typeof(IRequestHandler<,>))
                .InstancePerLifetimeScope();

            cb.RegisterGeneric(typeof(GetQueryHandler<>))
                .As(typeof(IRequestHandler<,>))
                .InstancePerLifetimeScope();
        }
    }
}
