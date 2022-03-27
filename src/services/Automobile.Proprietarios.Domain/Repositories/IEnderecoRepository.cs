using System;
using System.Threading.Tasks;
using Automobile.Core.Data;
using Automobile.Proprietarios.Domain.Entities;

namespace Automobile.Proprietarios.Domain.Repositories
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        void Adicionar(Endereco endereco);
        void Atualizar(Endereco endereco);
        Task<Endereco> ObterEnderecoPeloProprietarioId(Guid endereco);
    }
}