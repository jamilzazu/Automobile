using System;
using Automobile.Core.DomainObjects;

namespace Automobile.Proprietarios.API.Models
{
    public class Proprietario : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public Cpf Cpf { get; private set; }
        public bool Cancelado { get; private set; }
        public Endereco Endereco { get; private set; }

        // EF Relation
        protected Proprietario() { }

        public Proprietario(Guid id, string nome, string email, string cpf, Endereco endereco)
        {
            Id = id;
            Nome = nome;
            Email = new Email(email);
            Cpf = new Cpf(cpf);
            Cancelado = false;
            Endereco = endereco;
        }

        public void TrocarEmail(string email)
        {
            Email = new Email(email);
        }

        public void AtribuirEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }
    }
}