using Automobile.Core.Messages;
using Automobile.Proprietarios.API.Models.Enums;
using System;

namespace Automobile.Proprietarios.API.Application.Events
{
    public class ProprietarioAtivadoEvent : Event
    {
        public Guid Id { get; private set; }
        public Cancelado Status { get; private set; }


        public ProprietarioAtivadoEvent(Guid id, Cancelado status)
        {
            AggregateId = id;
            Status = status;
        }
    }
}
