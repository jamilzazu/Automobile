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
        public string Cep { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataAlteracao { get; private set; }
        
        [JsonPropertyOrder(1)]
        public Guid ProprietarioId { get; private set; }

        // EF Relation
        [JsonIgnore]
        public Proprietario Proprietario { get; protected set; }

        public Endereco(Guid id, Guid proprietarioId, string logradouro, string numero, string complemento, string bairro, string cep, string cidade, string estado)
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
        }

        public void Atualizar(string logradouro, string numero, string complemento, string bairro, string cep, string cidade, string estado)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;
        }
    }
}