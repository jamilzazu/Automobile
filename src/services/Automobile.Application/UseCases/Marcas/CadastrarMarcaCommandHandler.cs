using Automobile.Core.Enums;
using Automobile.Core.Messages;
using Automobile.Domain.Commands.Proprietario;
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

        public CadastrarMarcaCommandHandler(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public async Task<ValidationResult> Handle(CadastrarMarcaCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            //if (MarcaJaExiste(message.nome))
            //{
            //    AdicionarErro($"Este {message.Documento.TipoDocumentoDescricao()} já está em uso.");
            //    return ValidationResult;
            //}

            var marca = MontaObjetoMarca(message);

            _marcaRepository.Adicionar(marca);

            return await PersistirDados(_marcaRepository.UnitOfWork);
        }

        public static Marca MontaObjetoMarca(CadastrarMarcaCommand message)
        {
            return new Marca(message.Id, message.Nome, Cancelado.Nao);
        }

        //public bool MarcaJaExiste(string nomeMarca)
        //{
        //    var marcaJaExiste = _marcaRepository;

        //    return marcaJaExiste.Result != null;
        //}

        public void CadastrarMarca(Marca marca)
        {
            _marcaRepository.Adicionar(marca);
        }
    }
}
