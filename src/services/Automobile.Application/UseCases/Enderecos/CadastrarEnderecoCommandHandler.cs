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

namespace Automobile.Enderecos.Domain.Handlers.Enderecos
{
    public class CadastrarEnderecoCommandHandler : CommandHandler, IRequestHandler<CadastrarEnderecoCommand, ValidationResult>
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IProprietarioRepository _proprietarioRepository;

        public CadastrarEnderecoCommandHandler(IEnderecoRepository enderecoRepository, IProprietarioRepository proprietarioRepository)
        {
            _enderecoRepository = enderecoRepository;
            _proprietarioRepository = proprietarioRepository;
        }

        public async Task<ValidationResult> Handle(CadastrarEnderecoCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            if (!VerificaSeExisteProprietario(message.ProprietarioId))
            {
                AdicionarErro("Proprietário não encontrado.");
                return ValidationResult;
            }

            var endereco = MontaObjetoEndereco(message);

            _enderecoRepository.Adicionar(endereco);

            return await PersistirDados(_enderecoRepository.UnitOfWork);
        }

    
        public bool VerificaSeExisteProprietario(Guid proprietarioId)
        {
            bool existeProprietario = _proprietarioRepository.ObterProprietarioPeloId(proprietarioId).Result != null;

            return existeProprietario;
        }

        public static Endereco MontaObjetoEndereco(CadastrarEnderecoCommand message)
        {
            return new Endereco(message.Id, message.ProprietarioId, message.Logradouro, message.Numero, message.Complemento, message.Bairro, message.Cep, message.Cidade, message.Estado);
        }

        public void CadastrarEndereco(Endereco endereco, CadastrarEnderecoCommand message)
        {
            _enderecoRepository.Adicionar(endereco);

            AdicionarEventoDeCadastroDoEndereco(endereco, message);
        }

        public static void AdicionarEventoDeCadastroDoEndereco(Endereco endereco, CadastrarEnderecoCommand message)
        {
            endereco.AdicionarEvento(new EnderecoCadastradoEvent(message.Id, message.ProprietarioId, message.Logradouro, message.Numero, message.Complemento, message.Bairro, message.Cep, message.Cidade, message.Estado, message.DataCadastro));
        }
    }
}
