using Microsoft.Extensions.DependencyInjection;
using Automobile.Core.Mediator;
using Automobile.Proprietarios.Domain.Repositories;
using Automobile.Proprietarios.Infra.EF;
using Automobile.Proprietarios.Application.Queries.Interfaces;
using Automobile.Proprietarios.Domain.Queries;
using Automobile.Proprietarios.Domain.Handlers;
using MediatR;
using Automobile.Proprietarios.Domain.Commands.Proprietario;
using FluentValidation.Results;
using Automobile.Proprietarios.Application.Services;
using Automobile.Proprietarios.Application.Services.Interfaces;

namespace Automobile.Proprietarios.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IMediatorHandler, MediatorHandler>();

            // Proprietário

            services.AddScoped<IProprietarioRepository, ProprietarioRepository>();
            services.AddScoped<IProprietarioQueries, ProprietarioQueries>();
            services.AddScoped<IProprietarioService, ProprietarioService>();

            services.AddScoped<IRequestHandler<CadastrarProprietarioCommand, ValidationResult>, CadastrarProprietarioCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarProprietarioCommand, ValidationResult>, AtualizarProprietarioCommandHandler>();
            services.AddScoped<IRequestHandler<AtivarProprietarioCommand, ValidationResult>, AtivarProprietarioCommandHandler>();
            services.AddScoped<IRequestHandler<CancelarProprietarioCommand, ValidationResult>, CancelarProprietarioCommandHandler>();


            //// Proprietário
            //services.AddScoped<IProprietarioRepository, ProprietarioRepository>();
            //services.AddScoped<ProprietarioModelBuilder>();

            //services.AddScoped<IRequestHandler<CadastrarProprietarioCommand, ValidationResult>, ProprietarioCommandHandler>();
            //services.AddScoped<INotificationHandler<ProprietarioRegistradoEvent>, ProprietarioEventHandler>();

            //services.AddScoped<IRequestHandler<AlterarProprietarioCommand, ValidationResult>, ProprietarioCommandHandler>();
            //services.AddScoped<INotificationHandler<ProprietarioAlteradoEvent>, ProprietarioEventHandler>();

            //services.AddScoped<IRequestHandler<CancelarProprietarioCommand, ValidationResult>, ProprietarioCommandHandler>();
            //services.AddScoped<INotificationHandler<ProprietarioCanceladoEvent>, ProprietarioEventHandler>();

            //services.AddScoped<IRequestHandler<AtivarProprietarioCommand, ValidationResult>, ProprietarioCommandHandler>();
            //services.AddScoped<INotificationHandler<ProprietarioAtivadoEvent>,ProprietarioEventHandler>();


            //// Endereço

            //services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            //services.AddScoped<EnderecoModelBuilder>();

            //services.AddScoped<IRequestHandler<RegistrarEnderecoCommand, ValidationResult>, EnderecoCommandHandler>();
            //services.AddScoped<INotificationHandler<EnderecoRegistradoEvent>, EnderecoEventHandler>();

            //services.AddScoped<IRequestHandler<AlterarEnderecoCommand, ValidationResult>, EnderecoCommandHandler>();
            //services.AddScoped<INotificationHandler<EnderecoAlteradoEvent>, EnderecoEventHandler>();


            // Context
            //services.AddScoped<ProprietariosContext>();
        }
    }
}