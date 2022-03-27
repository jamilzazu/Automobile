using Automobile.Core.Messages;
using Automobile.Proprietarios.Application.Validators.Proprietario;
using Automobile.Proprietarios.Domain.Entities.Objects;
using System;

namespace Automobile.Proprietarios.Domain.Commands.Proprietario
{
    public class CadastrarProprietarioCommand : Command
    {
        public Guid Id { get; private set; }
        public string Nome { get; set; }
        public Documento Documento { get; set; }
        public string Email { get; set; }

        public CadastrarProprietarioCommand(string nome, Documento documento, string email)
        {
            Id = Guid.NewGuid();
            AggregateId = Id;
            Nome = nome;
            Documento = documento;
            Email = email;
        }
        public override bool EhValido()
        {
            ValidationResult = new CadastrarProprietarioCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
