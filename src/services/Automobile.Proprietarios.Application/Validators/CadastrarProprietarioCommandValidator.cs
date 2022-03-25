using Automobile.Proprietarios.Domain.Commands.Proprietario;
using Automobile.Proprietarios.Domain.Entities.Objects;
using FluentValidation;
using System;

namespace Automobile.Proprietarios.Application.Validators
{
    public class CadastrarProprietarioCommandValidator : AbstractValidator<CadastrarProprietarioCommand>
    {
        public CadastrarProprietarioCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do proprietário inválido");

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome do proprietário não foi informado");

            RuleFor(c => c.Documento)
                .NotEmpty()
                .WithMessage("O documento do proprietário não foi informado")
                //.Must(TerCpfValido()
                .WithMessage("O documento informado não é válido.");

            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("O e-mail do proprietário não foi informado")
                .Must(TerEmailValido)
                .WithMessage("O e-mail informado não é válido.");
        }

        //protected static bool TerCpfValido(TipoDocumento tipoDocumento, string cpf)
        //{
        //    return Core.DomainObjects.Documento.Validar(cpf);
        //}

        protected static bool TerEmailValido(string email)
        {
            return Email.Validar(email);
        }
    }
}
