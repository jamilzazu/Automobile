using Automobile.Core.Messages;
using Automobile.Proprietarios.API.Models.Enums;
using FluentValidation;
using System;

namespace Automobile.Proprietarios.API.Application.Commands
{
    public class AtivarProprietarioCommand : Command
    {
        public Guid Id { get; private set; }
        public Cancelado Status { get; private set; }


        public AtivarProprietarioCommand(Guid id, Cancelado status)
        {
            AggregateId = id;
            Id = id;
            Status = status;
        }

        public override bool EhValido()
        {
            ValidationResult = new AtivarProprietarioValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AtivarProprietarioValidation : AbstractValidator<AtivarProprietarioCommand>
    {
        public AtivarProprietarioValidation()
        {
            //RuleFor(c => c.Cancelado)
            //    .Equals(true)
            //    .WithMessage("Id do proprietário inválido");
        }
    }
}
