using Automobile.Core.Messages;
using Automobile.Proprietarios.Application.Validators.Endereco;
using System;

namespace Automobile.Proprietarios.Domain.Commands.Endereco
{
    public class CadastrarEnderecoCommand : Command
    {
        public Guid Id { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cep { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public Guid ProprietarioId { get; private set; }

        public CadastrarEnderecoCommand()
        {
        }

        public CadastrarEnderecoCommand(Guid proprietarioId, string logradouro, string numero, string complemento, string bairro, string cep, string cidade, string estado)
        {
            Id = Guid.NewGuid();
            AggregateId = Id;
            ProprietarioId = proprietarioId;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;
        }


        public override bool EhValido()
        {
            ValidationResult = new CadastrarEnderecoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
