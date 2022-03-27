using Automobile.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Automobile.Application.Services.Interfaces
{
    public interface IEnderecoService
    {
        Task<Endereco> ObterEnderecoPeloProprietarioId(Guid idProprietario);
    }
}
