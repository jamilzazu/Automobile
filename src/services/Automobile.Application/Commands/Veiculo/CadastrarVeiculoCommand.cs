using Automobile.Core.Messages;
using System;
using Automobile.Domain.Entities;
using Automobile.Application.Validators.Veiculo;

namespace Automobile.Domain.Commands.Veiculo
{
    public class CadastrarVeiculoCommand : Command
    {
        public Guid Id { get; set; }
        public Guid ProprietarioId { get; set; }
        public Guid MarcaId { get; set; }
        public string Renavam { get; set; }
        public Modelo Modelo { get; set; }
        public decimal Quilometragem { get; set; }
        public decimal Valor { get; set; }

        public CadastrarVeiculoCommand(Guid proprietarioId, Guid marcaId, Modelo modelo, string renavam, decimal quilometragem, decimal valor)
        {
            Id = Guid.NewGuid();
            AggregateId = Id;
            ProprietarioId = proprietarioId;
            MarcaId = marcaId;
            Renavam = renavam;
            Modelo = modelo;
            Quilometragem = quilometragem;
            Valor = valor;
        }


        public override bool EhValido()
        {
            ValidationResult = new CadastrarVeiculoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
