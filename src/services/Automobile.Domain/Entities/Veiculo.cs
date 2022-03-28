//using System;
//using Automobile.Core.DomainObjects;
//using Automobile.Core.Enums;
//using Automobile.Domain.Entities.Enums;
//using Automobile.Domain.Entities.Objects;

//namespace Automobile.Domain.Entities
//{
//    public class Veiculo : Entity, IAggregateRoot
//    {
//        public Guid ProprietarioId { get; private set; }
//        public Guid MarcaId { get; private set; }
//        public string Renavam { get; private set; }
//        public string Modelo { get; private set; }
//        public string AnoFabricacao { get; private set; }
//        public string AnoModelo { get; private set; }
//        public decimal Quilometragem { get; private set; }
//        public string Valor { get; private set; }
//        public StatusFluxo Cancelado { get; private set; }
//        public DateTime DataCadastro { get; private set; }
//        public DateTime? DataAlteracao { get; private set; }

//        // EF Relation
//        protected Veiculo() { }


//        public Veiculo(Guid proprietarioId, Guid marcaId, string renavam, string modelo, string anoFabricacao, string anoModelo, decimal quilometragem, string valor, StatusFluxo cancelado)
//        {
//            ProprietarioId = proprietarioId;
//            MarcaId = marcaId;
//            Renavam = renavam;
//            Modelo = modelo;
//            AnoFabricacao = anoFabricacao;
//            AnoModelo = anoModelo;
//            Quilometragem = quilometragem;
//            Valor = valor;
//            Cancelado = cancelado;
//        }

//        public void Atualizar(Guid marcaId, string renavam, string modelo, string anoFabricacao, string anoModelo, decimal quilometragem, string valor, StatusFluxo cancelado)
//        {
//            MarcaId = marcaId;
//            Renavam = renavam;
//            Modelo = modelo;
//            AnoFabricacao = anoFabricacao;
//            AnoModelo = anoModelo;
//            Quilometragem = quilometragem;
//            Valor = valor;
//            Cancelado = cancelado;
//        }

//        public void Cancelar()
//        {
//            Cancelado = Cancelado.Sim;
//        }

//        public void Ativar()
//        {
//            Cancelado = Cancelado.Nao;
//        }
//    }
//}