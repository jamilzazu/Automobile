using Automobile.Core.DomainObjects;
using Automobile.Domain.Entities.Enums;
using Automobile.Domain.Entitites;
using System;

namespace Automobile.Domain.Entities
{
    public class Veiculo : Entity, IAggregateRoot
    {
        public Guid ProprietarioId { get; private set; }
        public Guid MarcaId { get; private set; }
        public string Renavam { get; private set; }
        public Modelo Modelo { get; private set; }
        public decimal Quilometragem { get; private set; }
        public decimal Valor { get; private set; }
        public FluxoRevenda Status { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataAlteracao { get; private set; }


        // EF Relation
        public Marca Marca { get; protected set; }
        public Proprietario Proprietario { get; protected set; }
        protected Veiculo() { }


        public Veiculo(Guid id, Guid proprietarioId, Guid marcaId, Modelo modelo, string renavam, decimal quilometragem, decimal valor, FluxoRevenda status)
        {
            Id = id;
            ProprietarioId = proprietarioId;
            MarcaId = marcaId;
            Modelo = modelo;
            Renavam = renavam;
            Quilometragem = quilometragem;
            Valor = valor;
            Status = status;
        }

        public void Atualizar(Modelo modelo, string renavam, decimal quilometragem, decimal valor, FluxoRevenda status)
        {
            Modelo = modelo;
            Renavam = renavam;
            Quilometragem = quilometragem;
            Valor = valor;
            Status = status;
        }

        public void Disponibilizar() => Status = FluxoRevenda.Disponivel;
        public void Indisponibilizar() => Status = FluxoRevenda.Indisponivel;
        public void Vender() => Status = FluxoRevenda.Vendido;
    }
}