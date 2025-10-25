using Microsoft.Extensions.DependencyInjection;
using SGA.Application.Interfaces;
using SGA.Application.Services;
using SGA.Domain.Repository;
using SGA.Persistence.Repositories;

namespace SG.IOC;

public static class DependencyInjection
{
    public static IServiceCollection AddSgaServices(this IServiceCollection services)
    {
     
        services.AddScoped<ILibroService, LibroService>();
        services.AddScoped<IAutorService, AutorService>();
        services.AddScoped<IEjemplarService, EjemplarService>();
        services.AddScoped<IPrestamoService, PrestamoService>();
        services.AddScoped<IReservaService, ReservaService>();

        
        services.AddScoped<IAutorRepository, AutorRepository>();
        services.AddScoped<ILibroRepository, LibroRepository>();
        services.AddScoped<IEjemplarRepository, EjemplarRepository>();
        services.AddScoped<IPrestamoRepository, PrestamoRepository>();
        services.AddScoped<IReservaRepository, ReservaRepository>();

        return services;
    }
}
