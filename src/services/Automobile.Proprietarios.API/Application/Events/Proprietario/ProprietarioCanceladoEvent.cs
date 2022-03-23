using Automobile.Core.Messages;
using Automobile.Proprietarios.API.Models.Enums;
using System;

namespace Automobile.Proprietarios.API.Application.Events
{
    public class ProprietarioCanceladoEvent : Event
    {
        public Guid Id { get; private set; }
        public Cancelado Status { get; private set; }


        public ProprietarioCanceladoEvent(Guid id, Cancelado status)
        {
            AggregateId = id;
            Status = status;
        }
    }
}
