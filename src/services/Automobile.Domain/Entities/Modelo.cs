using Automobile.Core.DomainObjects;
using System;
using System.Text.Json.Serialization;

namespace Automobile.Domain.Entities
{
    public class Modelo : Entity
    {
        public string Descricao { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }

        public Guid VeiculoId { get; set; }

        // EF Relation
        [JsonIgnore]
        public Veiculo Veiculo { get; protected set; }

        public Modelo(string descricao, int anoFabricacao, int anoModelo, Guid veiculoId)
        {
            Descricao = descricao;
            AnoFabricacao = anoFabricacao;
            AnoModelo = anoModelo;
            VeiculoId = veiculoId;
        }

        // EF Constructor
        protected Modelo() { }


        public void Atualizar(string descricao, int anoFabricacao, int anoModelo)
        {
            Descricao = descricao;
            AnoFabricacao = anoFabricacao;
            AnoModelo = anoModelo;
        }
    }
}