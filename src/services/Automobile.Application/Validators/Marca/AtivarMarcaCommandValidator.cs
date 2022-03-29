using Automobile.Domain.Commands.Marca;
using FluentValidation;
using System;

namespace Automobile.Application.Validators.Proprietario
{
    public class AtivarMarcaCommandValidator : AbstractValidator<AtivarMarcaCommand>
    {
        public AtivarMarcaCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id da marca inválido");
        }
    }
}
