using Microsoft.Extensions.DependencyInjection;
using Automobile.Core.Mediator;
using Automobile.Proprietarios.Domain.Repositories;
using Automobile.Proprietarios.Infra.EF;
using Automobile.Proprietarios.Application.Queries.Interfaces;
using Automobile.Proprietarios.Domain.Queries;
using Automobile.Proprietarios.Domain.Handlers.Proprietarios;
using MediatR;
using Automobile.Proprietarios.Domain.Commands.Proprietario;
using FluentValidation.Results;
using Automobile.Proprietarios.Application.Services;
using Automobile.Proprietarios.Application.Services.Interfaces;
using Automobile.Proprietarios.Domain.Handlers.Proprietarioss;
using Automobile.Enderecos.Infra.EF;
using Automobile.Proprietarios.Domain.Commands.Endereco;
using Automobile.Proprietarios.Domain.Handlers.Enderecos;
using Automobile.Enderecos.Domain.Handlers.Enderecos;

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


            // Endereço

            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IEnderecoService, EnderecoService>();

            services.AddScoped<IRequestHandler<CadastrarEnderecoCommand, ValidationResult>, CadastrarEnderecoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarEnderecoCommand, ValidationResult>, AtualizarEnderecoCommandHandler>();
        }
    }
}