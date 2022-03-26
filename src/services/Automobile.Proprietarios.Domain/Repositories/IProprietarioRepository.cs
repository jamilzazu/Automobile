using System; 
using System.Threading.Tasks;
using Automobile.Core.Data;
using Automobile.Proprietarios.Domain.Entities;
using Automobile.Proprietarios.Domain.Entities.Objects;

namespace Automobile.Proprietarios.Domain.Repositories
{
    public interface IProprietarioRepository : IRepository<Proprietario>
    {
        void Adicionar(Proprietario proprietario);
        void Atualizar(Proprietario proprietario);
        Task<Proprietario> ObterProprietarioPeloId(Guid id);
        Task<Proprietario> ObterProprietarioPeloNumeroDocumento(Documento documento);
    }
}