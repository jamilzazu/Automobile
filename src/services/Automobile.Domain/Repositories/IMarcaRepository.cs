using Automobile.Core.Data;
using Automobile.Domain.Entitites;
using System;
using System.Threading.Tasks;

namespace Automobile.Domain.Repositories
{
    public interface IMarcaRepository : IRepository<Marca>
    {
        void Adicionar(Marca marca);
        void Atualizar(Marca marca);
        Task<Marca> ObterMarcaPeloId(Guid id);
        Task<Marca> ObterMarcaPeloNome(string nome);
    }
}