using System; 
using System.Threading.Tasks;
using Automobile.Core.Data;
using Automobile.Domain.Entities;

namespace Automobile.Domain.Repositories
{
    public interface IVeiculoRepository : IRepository<Veiculo>
    {
        void Adicionar(Veiculo veiculo);
        void Atualizar(Veiculo veiculo);
        Task<Veiculo> ObterVeiculoPeloId(Guid id);
        Task<Veiculo> ObterVeiculoPeloNumeroRenavam(string renavam);
    }
}