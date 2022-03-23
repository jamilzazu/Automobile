using Automobile.Core.Messages;
using System;

namespace Automobile.Proprietarios.API.Application.Events
{
    public class ProprietarioAtivadoEvent : Event
    {
        public Guid Id { get; private set; }
        public bool Status { get; private set; }


        public ProprietarioAtivadoEvent(Guid id, bool status)
        {
            AggregateId = id;
            Status = status;
        }
    }
}
