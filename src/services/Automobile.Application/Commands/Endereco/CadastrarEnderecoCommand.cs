using Automobile.Core.Messages;
using Automobile.Application.Validators.Endereco;
using System;

namespace Automobile.Domain.Commands.Endereco
{
    public class CadastrarEnderecoCommand : Command
    {
        public Guid Id { get; private set; }
        public Guid ProprietarioId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string CodigoIbgeCidade { get; set; }
        public string CodigoIbgeEstado { get; set; }
        public DateTime DataCadastro { get; private set; }

        public CadastrarEnderecoCommand()
        {
        }

        public CadastrarEnderecoCommand(Guid proprietarioId, string logradouro, string numero, string complemento, string bairro, string cep, string codigoIbgeCidade, string codigoIbgeEstado, DateTime dataCadastro)
        {
            Id = Guid.NewGuid();
            AggregateId = Id;
            ProprietarioId = proprietarioId;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            CodigoIbgeCidade = codigoIbgeCidade;
            CodigoIbgeEstado = codigoIbgeEstado;
            DataCadastro = dataCadastro;
        }


        public override bool EhValido()
        {
            ValidationResult = new CadastrarEnderecoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
