using System;
using System.Text.Json.Serialization;
using Automobile.Core.DomainObjects;

namespace Automobile.Domain.Entities
{
    public class Endereco : Entity, IAggregateRoot
    {
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public int Cep { get; private set; }
        public int CodigoIbgeCidade { get; private set; }
        public int CodigoIbgeEstado { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataAlteracao { get; private set; }

        [JsonPropertyOrder(1)]
        public Guid ProprietarioId { get; private set; }

        // EF Relation
        [JsonIgnore]
        public Proprietario Proprietario { get; protected set; }

        public Endereco(Guid id, Guid proprietarioId, string logradouro, string numero, string complemento, string bairro, int cep, int codigoIbgeCidade, int codigoIbgeEstado)
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
        }

        public void Atualizar(string logradouro, string numero, string complemento, string bairro, int cep, int codigoIbgeCidade, int codigoIbgeEstado)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            CodigoIbgeCidade = codigoIbgeCidade;
            CodigoIbgeEstado = codigoIbgeEstado;
        }
    }
}