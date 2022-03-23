using Automobile.Core.Messages;
using Automobile.Proprietarios.API.Models.Enums;
using FluentValidation;
using System;

namespace Automobile.Proprietarios.API.Application.Commands
{
    public class RegistrarProprietarioCommand : Command
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public TipoDocumento TipoDocumento { get; private set; }
        public string Documento { get; private set; }
        public string Email { get; private set; }

        public RegistrarProprietarioCommand(Guid id, string nome, TipoDocumento tipoDocumento, string documento, string email)
        {
            AggregateId = id;
            Id = id;
            Nome = nome;
            TipoDocumento = tipoDocumento;
            Documento = documento;
            Email = email;
        }

        public override bool EhValido()
        {
            ValidationResult = new RegistrarProprietarioValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class RegistrarProprietarioValidation : AbstractValidator<RegistrarProprietarioCommand>
    {
        public RegistrarProprietarioValidation()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do proprietário inválido");

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome do proprietário não foi informado");

            RuleFor(c => c.Documento)
                .NotEmpty()
                .WithMessage("O documento do proprietário não foi informado")
                //.Must(TerCpfValido()
                .WithMessage("O documento informado não é válido.");

            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("O e-mail do proprietário não foi informado")
                .Must(TerEmailValido)
                .WithMessage("O e-mail informado não é válido.");
        }

        protected static bool TerCpfValido(TipoDocumento tipoDocumento, string cpf)
        {
            return Core.DomainObjects.Documento.Validar(cpf);
        }

        protected static bool TerEmailValido(string email)
        {
            return Core.DomainObjects.Email.Validar(email);
        }
    }
}
