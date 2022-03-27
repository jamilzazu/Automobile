using Automobile.Proprietarios.Domain.Entities;
using System;

namespace Automobile.Proprietarios.Domain.Test.Repositories.Interfaces
{
    public interface IProprietarioRepository
    {
        Proprietario ObterProprietarioPeloId(Guid id);
    }
}
