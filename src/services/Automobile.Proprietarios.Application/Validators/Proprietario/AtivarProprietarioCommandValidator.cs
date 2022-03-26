using Automobile.Proprietarios.Domain.Commands.Proprietario;
using FluentValidation;
using System;

namespace Automobile.Proprietarios.Application.Validators.Proprietario
{
    public class AtivarProprietarioCommandValidator : AbstractValidator<AtivarProprietarioCommand>
    {
        public AtivarProprietarioCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do proprietário inválido");
        }
    }
}
