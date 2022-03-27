using Automobile.Core.Messages;
using Automobile.Proprietarios.Application.Validators.Endereco;
using System;

namespace Automobile.Proprietarios.Domain.Commands.Endereco
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
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateTime DataCadastro { get; private set; }

        public CadastrarEnderecoCommand()
        {
        }

        public CadastrarEnderecoCommand(Guid proprietarioId, string logradouro, string numero, string complemento, string bairro, string cep, string cidade, string estado, DateTime dataCadastro)
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
            DataCadastro = dataCadastro;
        }


        public override bool EhValido()
        {
            ValidationResult = new CadastrarEnderecoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
