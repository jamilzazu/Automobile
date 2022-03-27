using System;
using System.Threading.Tasks;
using Automobile.Core.Data;
using Automobile.Domain.Entities;

namespace Automobile.Domain.Repositories
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        void Adicionar(Endereco endereco);
        void Atualizar(Endereco endereco);
        Task<Endereco> ObterEnderecoPeloProprietarioId(Guid endereco);
    }
}