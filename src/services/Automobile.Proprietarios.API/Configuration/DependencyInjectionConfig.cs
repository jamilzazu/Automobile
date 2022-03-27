using Microsoft.Extensions.DependencyInjection;
using Automobile.Core.Mediator;
using Automobile.Domain.Repositories;
using Automobile.Proprietarios.Infra.EF;
using Automobile.Application.Queries.Interfaces;
using Automobile.Domain.Queries;
using Automobile.Domain.Handlers.Proprietarios;
using MediatR;
using Automobile.Domain.Commands.Proprietario;
using FluentValidation.Results;
using Automobile.Application.Services;
using Automobile.Application.Services.Interfaces;
using Automobile.Domain.Handlers.Proprietarioss;
using Automobile.Enderecos.Infra.EF;
using Automobile.Domain.Commands.Endereco;
using Automobile.Domain.Handlers.Enderecos;
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