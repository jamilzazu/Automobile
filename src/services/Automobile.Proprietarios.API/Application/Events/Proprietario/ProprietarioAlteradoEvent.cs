using Automobile.Core.Messages;
using System;

namespace Automobile.Proprietarios.API.Application.Events
{
    public class ProprietarioAlteradoEvent : Event
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public bool Status { get; private set; }


        public ProprietarioAlteradoEvent(Guid id, string nome, string cpf, string email, bool status)
        {
            AggregateId = id;
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Status = status;
        }
    }
}
