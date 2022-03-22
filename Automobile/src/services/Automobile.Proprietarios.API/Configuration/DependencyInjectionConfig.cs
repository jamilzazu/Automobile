using Microsoft.Extensions.DependencyInjection;
using Automobile.Proprietarios.API.Data;
using Automobile.Proprietarios.API.Data.Repository;
using Automobile.Proprietarios.API.Models;
using Automobile.Core.Mediator;
using MediatR;
using FluentValidation.Results;
using Automobile.Proprietarios.API.Application.Commands;

namespace Automobile.Proprietarios.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<RegistrarProprietarioCommand, ValidationResult>, ProprietarioCommandHandler>();

            services.AddScoped<IProprietarioRepository, ProprietarioRepository>();
            services.AddScoped<ProprietariosContext>();
        }
    }
}