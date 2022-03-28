using Automobile.Domain.Commands.Marca;
using FluentValidation;
using System;

namespace Automobile.Application.Validators.Marca
{
    public class CancelarMarcaCommandValidator : AbstractValidator<CancelarMarcaCommand>
    {
        public CancelarMarcaCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id da marca inválido");
        }
    }
}
