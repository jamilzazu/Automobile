using Microsoft.Extensions.DependencyInjection;
using Automobile.Proprietarios.API.Data;
using Automobile.Proprietarios.API.Data.Repository;
using Automobile.Proprietarios.API.Models;

namespace Automobile.Proprietarios.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProprietarioRepository, ProprietarioRepository>();
            services.AddScoped<ProprietariosContext>();
        }
    }
}