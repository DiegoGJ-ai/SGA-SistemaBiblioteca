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
        // ---------- Services (Application Layer) ----------
        // Libro: ya existe en tu proyecto (deja como esté, aquí lo reafirmamos por completitud)
        services.AddScoped<ILibroService, LibroService>();

        // NUEVOS servicios (agrega estos):
        services.AddScoped<IAutorService, AutorService>();
        services.AddScoped<IEjemplarService, EjemplarService>();
        services.AddScoped<IPrestamoService, PrestamoService>();
        services.AddScoped<IReservaService, ReservaService>();

        // ---------- Repositories (Persistence Layer) ----------
        // Ya existen, asegúrate de tenerlos registrados:
        services.AddScoped<IAutorRepository, AutorRepository>();
        services.AddScoped<ILibroRepository, LibroRepository>();
        services.AddScoped<IEjemplarRepository, EjemplarRepository>();
        services.AddScoped<IPrestamoRepository, PrestamoRepository>();
        services.AddScoped<IReservaRepository, ReservaRepository>();

        return services;
    }
}
