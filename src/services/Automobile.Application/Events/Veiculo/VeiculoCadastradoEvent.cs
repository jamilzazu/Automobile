using Automobile.Core.Messages;
using Automobile.Domain.Entities;
using System;

namespace Automobile.Application.Events.Veiculo
{
    public  class VeiculoCadastradoEvent : Event
    {
        public Guid Id { get; set; }
        public string Renavam { get; set; }
        public Modelo Modelo { get; set; }
        public decimal Quilometragem { get; set; }
        public decimal Valor { get; set; }

        public VeiculoCadastradoEvent(string renavam, Modelo modelo, decimal quilometragem, decimal valor)
        {
            AggregateId = Id;
            Renavam = renavam;
            Modelo = modelo;
            Quilometragem = quilometragem;
            Valor = valor;
        }
    }
}
