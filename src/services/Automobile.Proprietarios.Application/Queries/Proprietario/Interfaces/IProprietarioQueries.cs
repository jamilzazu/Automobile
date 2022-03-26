using Automobile.Proprietarios.Application.Queries.Dto;
using Automobile.Proprietarios.Domain.Entities.Objects;
using System;
using System.Threading.Tasks;

namespace Automobile.Proprietarios.Application.Queries.Interfaces
{
    public interface IProprietarioQueries
    {
        //IEnumerable<ProprietarioDto> ObterTodosProprietarios();
        Task<ProprietarioDto> ObterProprietarioPorId(Guid idProprietario);
        Task<ProprietarioDto> ObterProprietarioPeloNumeroDocumento(Documento documento);
    }
}
