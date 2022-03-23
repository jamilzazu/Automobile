using Automobile.Core.Messages;
using Automobile.Proprietarios.API.Application.Events;
using Automobile.Proprietarios.API.Models;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.Proprietarios.API.Application.Commands
{
    public class EnderecoCommandHandler : CommandHandler,
        IRequestHandler<RegistrarEnderecoCommand, ValidationResult>,
        IRequestHandler<AlterarEnderecoCommand, ValidationResult>

    {

        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoCommandHandler(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task<ValidationResult> Handle(RegistrarEnderecoCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var endereco = new Endereco(
                    message.Id,
                    message.Logradouro,
                    message.Numero,
                    message.Complemento,
                    message.Bairro,
                    message.Cep,
                    message.Cidade,
                    message.Estado,
                    message.ProprietarioId
                );

            _enderecoRepository.Adicionar(endereco);

            endereco.AdicionarEvento(new EnderecoRegistradoEvent(message.Id,
                    message.Logradouro,
                    message.Numero,
                    message.Complemento,
                    message.Bairro,
                    message.Cep,
                    message.Cidade,
                    message.Estado,
                    message.ProprietarioId));

            return await PersistirDados(_enderecoRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AlterarEnderecoCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var endereco = await _enderecoRepository.ObterPorProprietarioId(message.ProprietarioId);

            if (endereco == null)
            {
                AdicionarErro("Endereço não encontrado.");
                return ValidationResult;
            }

            endereco.Alterar(
                   message.Logradouro,
                   message.Numero,
                   message.Complemento,
                   message.Bairro,
                   message.Cep,
                   message.Cidade,
                   message.Estado
                );

            _enderecoRepository.Atualizar(endereco);

            endereco.AdicionarEvento(new EnderecoAlteradoEvent(message.Id, message.Logradouro,
                   message.Numero,
                   message.Complemento,
                   message.Bairro,
                   message.Cep,
                   message.Cidade,
                   message.Estado));

            return await PersistirDados(_enderecoRepository.UnitOfWork);
        }
    }
}
