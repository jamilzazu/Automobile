using Automobile.Core.Data;
using Automobile.Domain.Entitites;
using System;
using System.Threading.Tasks;

namespace Automobile.Domain.Repositories
{
    public interface IMarcaRepository : IRepository<Marca>
    {
        void Adicionar(Marca marca);
        Task<Marca> ObterMarcaPeloId(Guid id);
    }
}