using Automobile.Application.Queries.Request;
using Automobile.Application.Services.Interfaces;
using Automobile.Core.Enums;
using Automobile.Core.Messages;
using Automobile.Domain.Commands.Marca;
using Automobile.Domain.Entitites;
using Automobile.Domain.Repositories;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.Domain.Handlers.Marcas
{
    public class CadastrarMarcaCommandHandler : CommandHandler, IRequestHandler<CadastrarMarcaCommand, ValidationResult>
    {
        private readonly IMarcaRepository _marcaRepository;
        private readonly IMarcaService _marcaService;

        public CadastrarMarcaCommandHandler(IMarcaRepository marcaRepository, IMarcaService marcaService)
        {
            _marcaRepository = marcaRepository;
            _marcaService = marcaService;
        }

        public async Task<ValidationResult> Handle(CadastrarMarcaCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            if (MarcaJaExiste(message.Nome))
            {
                AdicionarErro($"A marca {message.Nome} já está existe.");
                return ValidationResult;
            }

            var marca = MontaObjetoMarca(message);

            _marcaRepository.Adicionar(marca);

            return await PersistirDados(_marcaRepository.UnitOfWork);
        }

        public static Marca MontaObjetoMarca(CadastrarMarcaCommand message)
        {
            return new Marca(message.Id, message.Nome, Cancelado.Nao);
        }

        public bool MarcaJaExiste(string nomeMarca)
        {
            var marcaJaExiste = _marcaService.ObterMarcaPeloNome(nomeMarca).Result != null;

            return marcaJaExiste;
        }

        public void CadastrarMarca(Marca marca)
        {
            _marcaRepository.Adicionar(marca);
        }
    }
}
