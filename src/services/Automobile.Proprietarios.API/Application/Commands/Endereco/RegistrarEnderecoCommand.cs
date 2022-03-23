using Automobile.Core.Messages;
using FluentValidation;
using System;

namespace Automobile.Proprietarios.API.Application.Commands
{
    public class RegistrarEnderecoCommand : Command
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

        public RegistrarEnderecoCommand()
        {
        }

        public RegistrarEnderecoCommand(Guid id, Guid proprietarioId, string logradouro, string numero, string complemento, string bairro, string cep, string cidade, string estado)
        {
            AggregateId = id;
            ProprietarioId = proprietarioId;
            Id = id;
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
            ValidationResult = new RegistrarEnderecoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class RegistrarEnderecoValidation : AbstractValidator<RegistrarEnderecoCommand>
    {
        public RegistrarEnderecoValidation()
        {
            RuleFor(c => c.Logradouro)
                   .NotEmpty()
                   .WithMessage("Informe o Logradouro");

            RuleFor(c => c.Numero)
                .NotEmpty()
                .WithMessage("Informe o Número");

            RuleFor(c => c.Cep)
                .NotEmpty()
                .WithMessage("Informe o CEP");

            RuleFor(c => c.Bairro)
                .NotEmpty()
                .WithMessage("Informe o Bairro");

            RuleFor(c => c.Cidade)
                .NotEmpty()
                .WithMessage("Informe o Cidade");

            RuleFor(c => c.Estado)
                .NotEmpty()
                .WithMessage("Informe o Estado");
        }
    }
}
