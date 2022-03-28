using Automobile.Domain.Commands.Proprietario;
using FluentValidation;
using System;

namespace Automobile.Application.Validators.Proprietario
{
    public class CadastrarMarcaCommandValidator : AbstractValidator<CadastrarMarcaCommand>
    {
        public CadastrarMarcaCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do proprietário inválido");

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome do proprietário não foi informado")
                .Length(5, 200)
                .WithMessage("O campo Nome deve ter entre 5 e 200 caracteres");
        }
    }
}
