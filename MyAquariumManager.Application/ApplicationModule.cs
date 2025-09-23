using Microsoft.Extensions.DependencyInjection;
using MyAquariumManager.Application.Interfaces.Services;
using MyAquariumManager.Application.Services;

namespace MyAquariumManager.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddServices();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IAnimalService, AnimalService>();
            services.AddTransient<IContaService, ContaService>();
            return services;
        }
    }
}
