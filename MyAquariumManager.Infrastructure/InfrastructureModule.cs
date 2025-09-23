using Microsoft.Extensions.DependencyInjection;
using MyAquariumManager.Core.Interfaces.Repositories;
using MyAquariumManager.Infrastructure.Data.Repositories;

namespace MyAquariumManager.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services
                .AddRepositorires();

            return services;
        }

        public static IServiceCollection AddRepositorires(this IServiceCollection services)
        {
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IAnimalRepository, AnimalRepository>();
            services.AddTransient<IContaRepository, ContaRepository>();

            return services;
        }
    }
}
