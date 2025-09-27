using Microsoft.Extensions.DependencyInjection;
using SGA.Domain.Repository;
using SGA.Persistence.Repositories;

namespace SG.IOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSgaServices(this IServiceCollection services)
        {
            // Repositorios
            services.AddScoped<ILibroRepository, LibroRepository>();

            return services;
        }
    }
}
