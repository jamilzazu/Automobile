using Automobile.Core.Messages;
using Automobile.Proprietarios.API.Models.Enums;
using FluentValidation;
using System;

namespace Automobile.Proprietarios.API.Application.Commands
{
    public class CancelarProprietarioCommand : Command
    {
        public Guid Id { get; private set; }
        public Cancelado Status { get; private set; }
        public DateTime? DataAlteracao { get; set; }


        public CancelarProprietarioCommand(Guid id, Cancelado status)
        {
            AggregateId = id;
            Id = id;
            Status = status;
        }

        public override bool EhValido()
        {
            ValidationResult = new CancelarProprietarioValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class CancelarProprietarioValidation : AbstractValidator<CancelarProprietarioCommand>
    {
        public CancelarProprietarioValidation()
        {
            //RuleFor(c => c.Cancelado)
            //    .Equals(true)
            //    .WithMessage("Id do proprietário inválido");
        }
    }
}
