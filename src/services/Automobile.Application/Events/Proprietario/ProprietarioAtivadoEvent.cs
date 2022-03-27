using Automobile.Core.Messages;
using Automobile.Domain.Entities.Objects;
using System;

namespace Automobile.Domain.Events.Proprietario
{
    public class ProprietarioAtivadoEvent : Event
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public Documento Documento { get; private set; }
        public string Email { get; private set; }


        public ProprietarioAtivadoEvent(Guid id, string nome, Documento documento, string email)
        {
            AggregateId = id;
            Id = id;
            Nome = nome;
            Documento = documento;
            Email = email;
        }
    }
}
