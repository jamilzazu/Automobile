using Microsoft.Extensions.DependencyInjection;
using Automobile.Core.Mediator;
using Automobile.Domain.Repositories;
using Automobile.Infra.EF;
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
using Automobile.Domain.Handlers.Marcas;
using Automobile.Domain.Handlers.Marcass;
using Automobile.Domain.Commands.Marca;
using Automobile.Domain.Commands.Veiculo;
using Automobile.Domain.Handlers.Veiculos;

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


            // Marca

            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<IMarcaQueries, MarcaQueries>();
            services.AddScoped<IMarcaService, MarcaService>();

            services.AddScoped<IRequestHandler<CadastrarMarcaCommand, ValidationResult>, CadastrarMarcaCommandHandler>();
            services.AddScoped<IRequestHandler<AtivarMarcaCommand, ValidationResult>, AtivarMarcaCommandHandler>();
            services.AddScoped<IRequestHandler<CancelarMarcaCommand, ValidationResult>, CancelarMarcaCommandHandler>();

            // Veículo

            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IVeiculoQueries, VeiculoQueries>();
            services.AddScoped<IVeiculoService, VeiculoService>();

            services.AddScoped<IRequestHandler<CadastrarVeiculoCommand, ValidationResult>, CadastrarVeiculoCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarVeiculoCommand, ValidationResult>, AtualizarVeiculoCommandHandler>();
            services.AddScoped<IRequestHandler<IndisponibilizarVeiculoCommand, ValidationResult>, IndisponibilizarVeiculoCommandHandler>();
            services.AddScoped<IRequestHandler<VenderVeiculoCommand, ValidationResult>, VenderVeiculoCommandHandler>();
        }
    }
}