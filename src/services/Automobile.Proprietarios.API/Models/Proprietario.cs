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
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataAlteracao { get; private set; }
        public Endereco Endereco { get; private set; }

        // EF Relation
        protected Proprietario() { }

        public Proprietario(Guid id, string nome, string email, string cpf)
        {
            Id = id;
            Nome = nome;
            Email = new Email(email);
            Cpf = new Cpf(cpf);
            Cancelado = false;
        }

        public string FormatarCPF(string cpf)
        {
            return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
        }

        public void Alterar(string nome, string email)
        {
            Nome = nome;
            Email = new Email(email);
        }

        public void Cancelar()
        {
            Cancelado = true;
        }

        public void Ativar()
        {
            Cancelado = false;
        }
    }
}