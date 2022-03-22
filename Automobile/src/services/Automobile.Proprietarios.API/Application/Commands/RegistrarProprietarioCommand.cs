using Automobile.Core.Messages;
using Automobile.Proprietarios.API.Models;
using System;

namespace Automobile.Proprietarios.API.Application.Commands
{
    public class RegistrarProprietarioCommand : Command
    {
        public RegistrarProprietarioCommand(Guid id, string nome, string cpf, string email, Endereco endereco)
        {
            AggregateId = id;
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Endereco = endereco;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public Endereco Endereco { get; private set; }

    }
}
