using Microsoft.Extensions.DependencyInjection;

// Application (si tienes servicios de aplicación)
using SGA.Application.Interfaces;
using SGA.Application.Services;

// Domain contracts
using SGA.Domain.Repository;

// Persistence implementations
using SGA.Persistence.Repositories;

namespace SG.IOC;

public static class DependencyInjection
{
    public static IServiceCollection AddSgaServices(this IServiceCollection services)
    {
        // Services de aplicación
        services.AddScoped<ILibroService, LibroService>();

        // Repositorios
        services.AddScoped<IAutorRepository, AutorRepository>();
        services.AddScoped<ILibroRepository, LibroRepository>();
        services.AddScoped<IEjemplarRepository, EjemplarRepository>();
        services.AddScoped<IPrestamoRepository, PrestamoRepository>();
        services.AddScoped<IReservaRepository, ReservaRepository>();

        return services;
    }
}
