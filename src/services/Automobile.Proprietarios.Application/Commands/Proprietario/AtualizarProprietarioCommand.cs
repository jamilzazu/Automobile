using Automobile.Core.Messages;
using Automobile.Proprietarios.Domain.Entities.Objects;
using FluentValidation;
using System;

namespace Automobile.Proprietarios.Domain.Commands.Proprietario
{
    public class AtualizarProprietarioCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Documento Documento { get; set; }
        public string Email { get; set; }

        public AtualizarProprietarioCommand(Guid id, string nome, Documento documento, string email)
        {
            AggregateId = id;
            Id = id;
            Nome = nome;
            Documento = documento;
            Email = email;
        }

        public override bool EhValido()
        {
            ValidationResult = new AlterarProprietarioValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AlterarProprietarioValidation : AbstractValidator<AtualizarProprietarioCommand>
    {
        public AlterarProprietarioValidation()
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
                //.Must(TerDocumentoValido)
                .WithMessage("O documento informado não é válido.");

            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("O e-mail do proprietário não foi informado")
                .Must(TerEmailValido)
                .WithMessage("O e-mail informado não é válido.");
        }

        //protected static bool TerDocumentoValido(string documento)
        //{
        //    return Validar(documento);
        //}

        protected static bool TerEmailValido(string email)
        {
            return  Email.Validar(email);
        }
    }
}
