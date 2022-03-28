using Automobile.Domain.Commands.Endereco;
using FluentValidation;

namespace Automobile.Application.Validators.Endereco
{
    public class AtualizarEnderecoCommandValidator : AbstractValidator<AtualizarEnderecoCommand>
    {
        public AtualizarEnderecoCommandValidator()
        {
            RuleFor(c => c.Logradouro)
                   .NotEmpty()
                   .WithMessage("Informe o Logradouro")
                   .Length(5, 200)
                   .WithMessage("O campo Logradouro deve ter entre 5 e 200 caracteres");

            RuleFor(c => c.Numero)
                .NotEmpty()
                .WithMessage("Informe o Número");

            RuleFor(c => c.Cep)
                .NotEmpty()
                .WithMessage("Informe o CEP");

            RuleFor(c => c.Bairro)
                .NotEmpty()
                .WithMessage("Informe o Bairro")
                .Length(3, 100)
                .WithMessage("O campo Bairro deve ter entre 3 e 100 caracteres");

            RuleFor(c => c.Cidade)
                .NotEmpty()
                .WithMessage("Informe o Cidade")
                .Length(5, 100)
                .WithMessage("O campo Bairro deve ter entre 5 e 100 caracteres");

            RuleFor(c => c.Estado)
                .NotEmpty()
                .WithMessage("Informe o Estado")
                .Length(2, 50)
                .WithMessage("O campo Bairro deve ter entre 2 e 50 caracteres");
        }
    }
}
