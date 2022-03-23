using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Automobile.Core.Data;

namespace Automobile.Proprietarios.API.Models
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        void Adicionar(Endereco endereco);
        void Atualizar(Endereco endereco);
        Task<Endereco> ObterPorProprietarioId(Guid proprietarioId);
    }
}