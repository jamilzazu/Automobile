using Automobile.Proprietarios.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Automobile.Proprietarios.Application.Services.Interfaces
{
    public interface IEnderecoService
    {
        Task<Endereco> ObterEnderecoPeloProprietarioId(Guid idProprietario);
    }
}
