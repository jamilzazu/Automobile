using Automobile.Application.Validators.Endereco;
using Automobile.Core.Messages;
using System;

namespace Automobile.Domain.Commands.Endereco
{
    public class AtualizarEnderecoCommand : Command
    {
        public Guid Id { get; set; }
        public Guid ProprietarioId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public int Cep { get; set; }
        public int CodigoIbgeCidade { get; set; }
        public int CodigoIbgeEstado { get; set; }
        public DateTime DataAlteracao { get; private set; }

        public AtualizarEnderecoCommand(Guid id, Guid proprietarioId, string logradouro, string numero, string complemento, string bairro, int cep, int codigoIbgeCidade, int codigoIbgeEstado, DateTime dataAlteracao)
        {
            Id = id;
            AggregateId = id;
            ProprietarioId = proprietarioId;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            CodigoIbgeCidade = codigoIbgeCidade;
            CodigoIbgeEstado = codigoIbgeEstado;
            DataAlteracao = dataAlteracao;
        }

        public override bool EhValido()
        {
            ValidationResult = new AtualizarEnderecoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

