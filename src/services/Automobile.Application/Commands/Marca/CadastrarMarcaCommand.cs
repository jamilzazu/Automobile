using Automobile.Core.Messages;
using Automobile.Application.Validators.Marca;
using System;

namespace Automobile.Domain.Commands.Marca
{
    public class CadastrarMarcaCommand : Command
    {
        public Guid Id { get; private set; }
        public string Nome { get; set; }

        public CadastrarMarcaCommand(string nome)
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
