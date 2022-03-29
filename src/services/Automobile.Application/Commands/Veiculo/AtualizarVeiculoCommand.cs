using Automobile.Core.Messages;
using System;
using Automobile.Domain.Entities;
using Automobile.Application.Validators.Veiculo;

namespace Automobile.Domain.Commands.Veiculo
{
    public class AtualizarVeiculoCommand : Command
    {
        public Guid Id { get; set; }
        public Guid ProprietarioId { get; private set; }
        public Guid MarcaId { get; private set; }
        public string Renavam { get; set; }
        public Modelo Modelo { get; set; }
        public decimal Quilometragem { get; set; }
        public decimal Valor { get; set; }

        public AtualizarVeiculoCommand(Guid id, Guid proprietarioId, Guid marcaId, Modelo modelo, string renavam, decimal quilometragem, decimal valor)
        {
            Id = id;
            ProprietarioId = proprietarioId;
            MarcaId = marcaId;
            Modelo = modelo;
            Renavam = renavam;
            Quilometragem = quilometragem;
            Valor = valor;
        }


        public override bool EhValido()
        {
            ValidationResult = new AtualizarVeiculoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
