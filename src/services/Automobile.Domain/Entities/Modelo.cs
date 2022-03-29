using Automobile.Core.DomainObjects;
using System;

namespace Automobile.Domain.Entities
{
    public class Modelo : Entity
    {
        public string Descricao { get; private set; }
        public int AnoFabricacao { get; private set; }
        public int AnoModelo { get; private set; }

        public Guid VeiculoId { get; private set; }

        // EF Relation
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