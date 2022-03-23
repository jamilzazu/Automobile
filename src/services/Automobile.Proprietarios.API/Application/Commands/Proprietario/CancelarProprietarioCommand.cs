using Automobile.Core.Messages;
using FluentValidation;
using System;

namespace Automobile.Proprietarios.API.Application.Commands
{
    public class CancelarProprietarioCommand : Command
    {
        public Guid Id { get; private set; }
        public bool Status { get; private set; }
        public DateTime? DataAlteracao { get; set; }


        public CancelarProprietarioCommand(Guid id, bool status)
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
            //RuleFor(c => c.Status)
            //    .Equals(true)
            //    .WithMessage("Id do proprietário inválido");
        }
    }
}
