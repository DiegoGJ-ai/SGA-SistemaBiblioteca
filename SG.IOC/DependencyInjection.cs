using Microsoft.Extensions.DependencyInjection;
using SGA.Application.Interfaces;
using SGA.Application.Services;
using SGA.Domain.Repository;
using SGA.Persistence.Repositories;

namespace SG.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSgaServices(this IServiceCollection services)
        {
            
            services.AddScoped<ILibroRepository, LibroRepository>();

          
            services.AddScoped<ILibroService, LibroService>();

            return services;
        }
    }
}
