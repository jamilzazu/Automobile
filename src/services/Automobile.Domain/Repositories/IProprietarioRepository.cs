using System; 
using System.Threading.Tasks;
using Automobile.Core.Data;
using Automobile.Domain.Entities;
using Automobile.Domain.Entities.Objects;

namespace Automobile.Domain.Repositories
{
    public interface IProprietarioRepository : IRepository<Proprietario>
    {
        void Adicionar(Proprietario proprietario);
        void Atualizar(Proprietario proprietario);
        Task<Proprietario> ObterProprietarioPeloId(Guid id);
        Task<Proprietario> ObterProprietarioPeloNumeroDocumento(Documento documento);
    }
}