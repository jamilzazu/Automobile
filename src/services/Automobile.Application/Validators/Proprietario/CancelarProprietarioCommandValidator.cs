using Automobile.Domain.Commands.Proprietario;
using Automobile.Domain.Entities.Objects;
using FluentValidation;
using System;

namespace Automobile.Application.Validators.Proprietario
{
    public class CancelarProprietarioCommandValidator : AbstractValidator<CancelarProprietarioCommand>
    {
        public CancelarProprietarioCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do proprietário inválido");
        }
    }
}
