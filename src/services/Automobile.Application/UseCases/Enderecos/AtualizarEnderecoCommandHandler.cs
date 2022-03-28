using Automobile.Core.Messages;
using Automobile.Domain.Commands.Endereco;
using Automobile.Domain.Entities;
using Automobile.Domain.Events.Endereco;
using Automobile.Domain.Repositories;
using FluentValidation.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.Domain.Handlers.Enderecos
{
    public class AtualizarEnderecoCommandHandler : CommandHandler, IRequestHandler<AtualizarEnderecoCommand, ValidationResult>
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IProprietarioRepository _proprietarioRepository;

        public AtualizarEnderecoCommandHandler(IEnderecoRepository enderecoRepository, IProprietarioRepository proprietarioRepository)
        {
            _enderecoRepository = enderecoRepository;
            _proprietarioRepository = proprietarioRepository;
        }

        public async Task<ValidationResult> Handle(AtualizarEnderecoCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            if (!VerificaSeExisteProprietario(message.ProprietarioId))
            {
                AdicionarErro("Proprietário não encontrado.");
                return ValidationResult;
            }

            var endereco = _enderecoRepository.ObterEnderecoPeloProprietarioId(message.ProprietarioId).Result;

            if (endereco == null)
            {
                AdicionarErro("Endereço do proprietário não encontrado.");
                return ValidationResult;
            }

            AtualizarEndereco(endereco, message);

            return await PersistirDados(_enderecoRepository.UnitOfWork);
        }

        public bool VerificaSeExisteProprietario(Guid proprietarioId)
        {
            bool existeProprietario = _proprietarioRepository.ObterProprietarioPeloId(proprietarioId).Result != null;

            return existeProprietario;
        }

        public void AtualizarEndereco(Endereco endereco, AtualizarEnderecoCommand message)
        {
            endereco.Atualizar(message.Logradouro, message.Numero, message.Complemento, message.Bairro, message.Cep, message.Cidade, message.Estado);

            _enderecoRepository.Atualizar(endereco);

            AdicionarEventoDeAtualizacaoDoEndereco(endereco, message);
        }

        public static void AdicionarEventoDeAtualizacaoDoEndereco(Endereco endereco, AtualizarEnderecoCommand message)
        {
            endereco.AdicionarEvento(new EnderecoAtualizadoEvent(message.Id, message.ProprietarioId, message.Logradouro, message.Numero, message.Complemento, message.Bairro, message.Cep, message.Cidade, message.Estado, message.DataAlteracao));
        }
    }
}
