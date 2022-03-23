using Microsoft.Extensions.DependencyInjection;
using Automobile.Proprietarios.API.Data;
using Automobile.Proprietarios.API.Data.Repository;
using Automobile.Proprietarios.API.Models;
using Automobile.Core.Mediator;
using FluentValidation.Results;
using Automobile.Proprietarios.API.Application.Commands;
using Automobile.Proprietarios.API.Application.Events;
using MediatR;

namespace Automobile.Proprietarios.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Proprietário
            services.AddScoped<IProprietarioRepository, ProprietarioRepository>();
            services.AddScoped<ProprietarioModelBuilder>();

            services.AddScoped<IRequestHandler<RegistrarProprietarioCommand, ValidationResult>, ProprietarioCommandHandler>();
            services.AddScoped<INotificationHandler<ProprietarioRegistradoEvent>, ProprietarioEventHandler>();

            services.AddScoped<IRequestHandler<AlterarProprietarioCommand, ValidationResult>, ProprietarioCommandHandler>();
            services.AddScoped<INotificationHandler<ProprietarioAlteradoEvent>, ProprietarioEventHandler>();

            services.AddScoped<IRequestHandler<CancelarProprietarioCommand, ValidationResult>, ProprietarioCommandHandler>();
            services.AddScoped<INotificationHandler<ProprietarioCanceladoEvent>, ProprietarioEventHandler>();

            services.AddScoped<IRequestHandler<AtivarProprietarioCommand, ValidationResult>, ProprietarioCommandHandler>();
            services.AddScoped<INotificationHandler<ProprietarioAtivadoEvent>,ProprietarioEventHandler>();


            // Endereço

            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<EnderecoModelBuilder>();

            services.AddScoped<IRequestHandler<RegistrarEnderecoCommand, ValidationResult>, EnderecoCommandHandler>();
            services.AddScoped<INotificationHandler<EnderecoRegistradoEvent>, EnderecoEventHandler>();

            services.AddScoped<IRequestHandler<AlterarEnderecoCommand, ValidationResult>, EnderecoCommandHandler>();
            services.AddScoped<INotificationHandler<EnderecoAlteradoEvent>, EnderecoEventHandler>();


            // Context
            services.AddScoped<ProprietariosContext>();
        }
    }
}