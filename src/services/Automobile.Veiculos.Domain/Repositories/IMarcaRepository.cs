using Automobile.Core.Data;
using Automobile.Veiculos.Domain.Entitites;
using System;
using System.Threading.Tasks;

namespace Automobile.Veiculos.Domain.Repositories
{
    public interface IMarcaRepository : IRepository<Marca>
    {
        void Adicionar(Marca marca);
        Task<Marca> ObterMarcaPeloId(Guid id);
    }
}
