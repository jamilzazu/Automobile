using Automobile.Core.Messages;
using FluentValidation;
using System;

namespace Automobile.Proprietarios.Domain.Commands.Endereco
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
            ValidationResult = new AlterarEnderecoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AlterarEnderecoValidation : AbstractValidator<AtualizarEnderecoCommand>
    {
        public AlterarEnderecoValidation()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do endereço inválido");

            RuleFor(c => c.Logradouro)
                .NotEmpty()
                .WithMessage("O logradouro do endereço não foi informado");

            RuleFor(c => c.Numero)
                .NotEmpty()
                .WithMessage("O número do endereço não foi informado");

            RuleFor(c => c.Bairro)
                .NotEmpty()
                .WithMessage("O bairro do endereço não foi informado");

            RuleFor(c => c.Cep)
                .NotEmpty()
                .WithMessage("O cep do endereço não foi informado");

            RuleFor(c => c.Cidade)
                .NotEmpty()
                .WithMessage("O cidade do endereço não foi informado");

            RuleFor(c => c.Estado)
                .NotEmpty()
                .WithMessage("O estado do endereço não foi informado");
        }
    }
}

