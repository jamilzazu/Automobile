using Automobile.Proprietarios.Domain.Commands.Proprietario;
using Automobile.Proprietarios.Domain.Entities.Enums;
using Automobile.Proprietarios.Domain.Entities.Objects;
using FluentValidation;
using System;

namespace Automobile.Proprietarios.Application.Validators.Proprietario
{
    public class AtualizarProprietarioCommandValidator : AbstractValidator<AtualizarProprietarioCommand>
    {
        public AtualizarProprietarioCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do proprietário inválido");

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome do proprietário não foi informado");

            RuleFor(c => c.Documento)
                .NotEmpty().WithMessage("O documento do proprietário não foi informado")
                .Must((o, documento) => { return TerDocumentoValido(documento); }).WithMessage(x => $"O {x.Documento.TipoDocumentoDescricao()} do proprietário informado não é válido");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O e-mail do proprietário não foi informado")
                .EmailAddress().WithMessage("O e-mail informado não é válido.");
        }

        protected static bool TerDocumentoValido(Documento documento)
        {
            return Documento.ValidarDocumento(documento.TipoDocumento, documento.NumeroDocumento);
        }
    }
}
