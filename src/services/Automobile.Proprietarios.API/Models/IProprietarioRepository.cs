using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Automobile.Core.Data;

namespace Automobile.Proprietarios.API.Models
{
    public interface IProprietarioRepository : IRepository<Proprietario>
    {
        void Adicionar(Proprietario proprietario);
        void Atualizar(Proprietario proprietario);
        Task<IEnumerable<Proprietario>> ObterTodos();
        Task<Proprietario> ObterPorDocumento(string documento);
        Task<Proprietario> ObterPorId(Guid id);
    }
}