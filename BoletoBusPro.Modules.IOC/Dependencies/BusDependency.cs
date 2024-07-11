using BoletoBusPro.Module.Application.Interfaces;
using BoletoBusPro.Module.Application.Services;
using BoletoBusPro.Module.Domain.Interfaces;
using BoletoBusPro.Module.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BoletoBusPro.Module.IOC.Dependencies
{
    public static class BusDependency
    {
        public static void AddBusDependency(this IServiceCollection service)
        {
            #region "Repositorios"
            service.AddScoped<IBusRepository, BusRepository>();
            service.AddScoped<IAsientoRepository, AsientoRepository>();
            #endregion

            #region "Services"
            service.AddTransient<IBusService, BusService>();
            service.AddTransient<IAsientoService, AsientoService>();
            #endregion
        }
    }
}
