using Automobile.Domain.Commands.Proprietario;
using Automobile.Domain.Entities.Enums;
using Automobile.Domain.Entities.Objects;
using FluentValidation;
using System;

namespace Automobile.Application.Validators.Proprietario
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
                .WithMessage("O nome do proprietário não foi informado")
                .Length(5, 200)
                .WithMessage("O campo Nome deve ter entre 5 e 200 caracteres");

            RuleFor(c => c.Documento)
                .NotEmpty()
                .WithMessage("O documento do proprietário não foi informado")
                .Must((o, documento) =>
                {
                    return TerDocumentoValido(documento);
                })
                .WithMessage(x => $"O {x.Documento.TipoDocumentoDescricao()} do proprietário informado não é válido");

            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("O e-mail do proprietário não foi informado")
                .EmailAddress()
                .WithMessage("O e-mail informado não é válido.")
                .Length(5, 200)
                .WithMessage("O campo E-mail deve ter entre 8 e 254 caracteres");
        }

        protected static bool TerDocumentoValido(Documento documento)
        {
            return Documento.ValidarDocumento(documento.TipoDocumento, documento.NumeroDocumento);
        }
    }
}
