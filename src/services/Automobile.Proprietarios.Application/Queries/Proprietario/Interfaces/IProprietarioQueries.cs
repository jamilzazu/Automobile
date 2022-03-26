using Automobile.Database.SqlServer.Order;
using Automobile.Proprietarios.Application.Queries.Dto;
using Automobile.Proprietarios.Application.Queries.Proprietario.Request;
using Automobile.Proprietarios.Application.Queries.Response;
using Automobile.Proprietarios.Domain.Entities.Objects;
using System;
using System.Threading.Tasks;

namespace Automobile.Proprietarios.Application.Queries.Interfaces
{
    public interface IProprietarioQueries
    {
        Task<PaginatedResult<ListaProprietarioResponse>> ListarProprietariosAsync(FiltroListaProprietariosRequest filtro);
        Task<ProprietarioDto> ObterProprietarioPorId(Guid idProprietario);
        Task<ProprietarioDto> ObterProprietarioPeloNumeroDocumento(Documento documento);
    }
}
