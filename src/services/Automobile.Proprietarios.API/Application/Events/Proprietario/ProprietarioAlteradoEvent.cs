using Automobile.Core.Messages;
using Automobile.Proprietarios.API.Models.Enums;
using System;

namespace Automobile.Proprietarios.API.Application.Events
{
    public class ProprietarioAlteradoEvent : Event
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public TipoDocumento TipoDocumento { get; private set; }
        public string Documento { get; private set; }
        public string Email { get; private set; }

        public ProprietarioAlteradoEvent(Guid id, string nome, TipoDocumento tipoDocumento, string documento, string email)
        {
            AggregateId = id;
            Nome = nome;
            TipoDocumento = tipoDocumento;
            Documento = documento;
            Email = email;
        }
    }
}
