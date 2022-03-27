using Automobile.Proprietarios.Domain.Commands.Endereco;
using FluentValidation;

namespace Automobile.Proprietarios.Application.Validators.Endereco
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
                .WithMessage("Informe o CEP")
                .Length(8)
                .WithMessage("O campo CEP deve ter 8 caracteres");

            RuleFor(c => c.Bairro)
                .NotEmpty()
                .WithMessage("Informe o Bairro")
                .Length(3, 100)
                .WithMessage("O campo Bairro deve ter entre 5 e 100 caracteres");

            RuleFor(c => c.Cidade)
                .NotEmpty()
                .WithMessage("Informe o Cidade")
                .Length(5, 100)
                .WithMessage("O campo Bairro deve ter entre 5 e 100 caracteres");

            RuleFor(c => c.Estado)
                .NotEmpty()
                .WithMessage("Informe o Estado")
                .Length(5, 50)
                .WithMessage("O campo Bairro deve ter entre 5 e 50 caracteres");
        }
    }
}
