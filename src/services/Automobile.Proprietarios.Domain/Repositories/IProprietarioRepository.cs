using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Automobile.Core.Data;
using Automobile.Proprietarios.Domain.Entities;
using Automobile.Proprietarios.Domain.Entities.Objects;

namespace Automobile.Proprietarios.Domain.Repositories
{
    public interface IProprietarioRepository : IRepository<Proprietario>
    {
        Proprietario Adicionar(Proprietario proprietario);
        Proprietario Atualizar(Proprietario proprietario);
        Task<Proprietario> ObterProprietarioPeloId(Guid id);
        Task<Proprietario> ObterProprietarioPeloNumeroDocumento(Documento documento);
        IEnumerable<Proprietario> ObterTodos();
    }
}