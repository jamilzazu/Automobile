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
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateTime DataAlteracao { get; private set; }

        public AtualizarEnderecoCommand(Guid id, Guid proprietarioId, string logradouro, string numero, string complemento, string bairro, string cep, string cidade, string estado, DateTime dataAlteracao)
        {
            Id = id;
            AggregateId = id;
            ProprietarioId = proprietarioId;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;
            DataAlteracao = dataAlteracao;
        }

        public override bool EhValido()
        {
            ValidationResult = new AtualizarEnderecoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

