using System;
using Automobile.Core.DomainObjects;
using Automobile.Proprietarios.API.Models.Enums;

namespace Automobile.Proprietarios.API.Models
{
    public class Proprietario : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public TipoDocumento TipoDocumento { get; private set; }
        public Documento Documento { get; private set; }
        public Cancelado Cancelado { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataAlteracao { get; private set; }
        public Endereco Endereco { get; private set; }

        // EF Relation
        protected Proprietario() { }

        public Proprietario(Guid id,
                            string nome,
                            TipoDocumento tipoDocumento,
                            string documento,
                            string email)
        {

            Id = id;
            Nome = nome;
            Email = new Email(email);
            TipoDocumento = tipoDocumento;
            Documento = new Documento(documento);
            Cancelado = Cancelado.Nao;
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
            Cancelado = Cancelado.Sim;
        }

        public void Ativar()
        {
            Cancelado = Cancelado.Nao;
        }
    }
}