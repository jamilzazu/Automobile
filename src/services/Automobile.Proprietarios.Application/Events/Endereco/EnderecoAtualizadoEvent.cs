using Automobile.Core.Messages;
using System;

namespace Automobile.Proprietarios.Domain.Events.Endereco
{
    public class EnderecoAtualizadoEvent : Event
    {
        public Guid Id { get; private set; }
        public Guid ProprietarioId { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cep { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public DateTime DataAlteracao { get; private set; }


        public EnderecoAtualizadoEvent(Guid id, Guid proprietarioId, string logradouro, string numero, string complemento, string bairro, string cep, string cidade, string estado, DateTime dataAlteracao)
        {
            Id = id;
            ProprietarioId = proprietarioId;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;
            DataAlteracao = dataAlteracao;
        }
    }
}
