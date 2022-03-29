﻿using Automobile.Core.Messages;
using System;
using Automobile.Domain.Entities;
using Automobile.Application.Validators.Veiculo;

namespace Automobile.Domain.Commands.Proprietario
{
    public class CadastrarVeiculoCommand : Command
    {
        public Guid Id { get; set; }
        public string Renavam { get; set; }
        public Modelo Modelo { get; set; }
        public decimal Quilometragem { get; set; }
        public decimal Valor { get; set; }

        public CadastrarVeiculoCommand(string renavam, Modelo modelo, decimal quilometragem, decimal valor)
        {
            Id = Guid.NewGuid();
            AggregateId = Id;
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
