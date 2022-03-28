using Automobile.Core.Messages;
using Automobile.Application.Validators.Proprietario;
using Automobile.Domain.Entities.Objects;
using System;

namespace Automobile.Domain.Commands.Proprietario
{
    public class CadastrarMarcaCommand : Command
    {
        public Guid Id { get; private set; }
        public string Nome { get; set; }

        public CadastrarMarcaCommand(string nome, Documento documento, string email)
        {
            Id = Guid.NewGuid();
            AggregateId = Id;
            Nome = nome;
        }
        public override bool EhValido()
        {
            ValidationResult = new CadastrarMarcaCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
