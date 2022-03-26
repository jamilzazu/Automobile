using Automobile.Core.Messages;
using Automobile.Proprietarios.Application.Validators;
using Automobile.Proprietarios.Domain.Entities.Objects;
using System;

namespace Automobile.Proprietarios.Domain.Commands.Proprietario
{
    public class AtualizarProprietarioCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Documento Documento { get; set; }
        public string Email { get; set; }

        public AtualizarProprietarioCommand(Guid id, string nome, Documento documento, string email)
        {
            AggregateId = id;
            Id = id;
            Nome = nome;
            Documento = documento;
            Email = email;
        }

        public override bool EhValido()
        {
            ValidationResult = new AtualizarProprietarioCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
