using System;
using Automobile.Core.DomainObjects;
using Automobile.Core.Enums;
using Automobile.Domain.Entities.Objects;

namespace Automobile.Domain.Entities
{
    public class Proprietario : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public Documento Documento { get; private set; }
        public Cancelado Cancelado { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataAlteracao { get; private set; }
        public Endereco Endereco { get; private set; }

        // EF Relation
        public Veiculo Veiculo { get; protected set; }
        protected Proprietario() { }

        public Proprietario(Guid id,
                            string nome,
                            Documento documento,
                            string email,
                            Cancelado cancelado)
        {
            Id = id;
            Nome = nome;
            Documento = documento;
            Email = new Email(email);
            Cancelado = cancelado;
        }


        public void Atualizar(string nome, Documento documento, string email)
        {
            Nome = nome;
            Documento = documento;
            Email = new Email(email);
        }

        public void Cancelar() => Cancelado = Cancelado.Sim;
        public void Ativar() => Cancelado = Cancelado.Nao;

    }
}