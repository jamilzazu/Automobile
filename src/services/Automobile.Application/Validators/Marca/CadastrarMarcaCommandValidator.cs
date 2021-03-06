using Automobile.Domain.Commands.Marca;
using FluentValidation;
using System;

namespace Automobile.Application.Validators.Marca
{
    public class CadastrarMarcaCommandValidator : AbstractValidator<CadastrarMarcaCommand>
    {
        public CadastrarMarcaCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do marca inválido");

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome da marca não foi informado")
                .Length(200)
                .WithMessage("O campo Nome deve ter entre 5 e 200 caracteres");
        }
    }
}
