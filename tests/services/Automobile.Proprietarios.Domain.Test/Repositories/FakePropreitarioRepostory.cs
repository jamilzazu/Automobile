using Automobile.Proprietarios.Domain.Entities;
using Automobile.Proprietarios.Domain.Entities.Enums;
using Automobile.Proprietarios.Domain.Entities.Objects;
using Automobile.Proprietarios.Domain.Test.Repositories.Interfaces;
using System;

namespace Automobile.Proprietarios.Domain.Test.Repositories
{
    public class FakePropreitarioRepostory : IProprietarioRepository
    {
        public Proprietario ObterProprietarioPeloId(Guid id)
        {
            if (id == Guid.Parse("a618f236-f2fb-42cc-879a-1922fe27ec37"))
            {
                return new Proprietario(id, "Jamil Zazu", new Documento(TipoDocumento.Cpf, "50958547000172"), "teste@teste.com", Domain.Entities.Enums.Cancelado.Nao);
            }

            return null;
        }
    }
}
