using System;

namespace Automobile.Core.Messages.Integration
{
    public class VeiculoCadastradoIntegrationEvent : IntegrationEvent
    {
        public Guid Id { get; private set; }
        public Guid ProprietarioId { get; set; }
        public Guid MarcaId { get; set; }
        public string Renavam { get; set; }
        public decimal Quilometragem { get; set; }
        public decimal Valor { get; set; }

        public VeiculoCadastradoIntegrationEvent(Guid proprietarioId, Guid marcaId, string renavam, decimal quilometragem, decimal valor)
        {
            Id = Guid.NewGuid();
            AggregateId = Id;
            ProprietarioId = proprietarioId;
            MarcaId = marcaId;
            Renavam = renavam;
            Quilometragem = quilometragem;
            Valor = valor;
        }
    }
}
