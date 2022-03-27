using Automobile.Core.DomainObjects;
using Automobile.Core.Enums;
using System;

namespace Automobile.Veiculos.Domain.Entitites
{
    public class Marca : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public Cancelado Cancelado { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataAlteracao { get; private set; }

        // EF Relation
        protected Marca() { }

        public Marca(Guid id, string nome, Cancelado cancelado)
        {
            Id = id;
            Nome = nome;
            Cancelado = cancelado;
        }

        public void Atualizar(string nome)
        {
            Nome = nome;
        }

        public void Cancelar()
        {
            Cancelado = Cancelado.Sim;
        }

        public void Ativar()
        {
            Cancelado = Cancelado.Nao;
        }
    }
}
