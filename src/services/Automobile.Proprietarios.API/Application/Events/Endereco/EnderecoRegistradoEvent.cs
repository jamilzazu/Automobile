using Automobile.Core.Messages;
using System;

namespace Automobile.Proprietarios.API.Application.Events
{
    public class EnderecoRegistradoEvent : Event
    {
        public Guid Id { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cep { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public Guid ProprietarioId { get; private set; }


        public EnderecoRegistradoEvent(Guid id, string logradouro, string numero, string complemento, string bairro, string cep, string cidade, string estado, Guid proprietarioId)
        {
            AggregateId = id;
            Id = id;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;
            ProprietarioId = proprietarioId;
        }

    }
}
