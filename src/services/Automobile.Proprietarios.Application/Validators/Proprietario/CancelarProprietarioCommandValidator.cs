using Automobile.Proprietarios.Domain.Commands.Proprietario;
using Automobile.Proprietarios.Domain.Entities.Objects;
using FluentValidation;
using System;

namespace Automobile.Proprietarios.Application.Validators.Proprietario
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
