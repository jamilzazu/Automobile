using Automobile.Core.Messages;
using System;

namespace Automobile.Domain.Events.Endereco
{
    public class EnderecoCadastradoEvent : Event
    {
        public Guid Id { get; private set; }
        public Guid ProprietarioId { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cep { get; private set; }
        public string CodigoIbgeCidade { get; private set; }
        public string CodigoIbgeEstado { get; private set; }
        public DateTime DataCadastro { get; private set; }


        public EnderecoCadastradoEvent(Guid id, Guid proprietarioId, string logradouro, string numero, string complemento, string bairro, string cep, string codigoIbgeCidade, string codigoIbgeEstado, DateTime dataCadastro)
        {
            Id = id;
            ProprietarioId = proprietarioId;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            CodigoIbgeCidade = codigoIbgeCidade;
            CodigoIbgeEstado = codigoIbgeEstado;
            DataCadastro = dataCadastro;
        }
    }
}
