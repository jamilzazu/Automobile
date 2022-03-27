using Automobile.Database.SqlServer.Order;
using Automobile.Application.Queries.Proprietario.Request;
using Automobile.Application.Queries.Response;
using Automobile.Domain.Entities;
using Automobile.Domain.Entities.Objects;
using System;
using System.Threading.Tasks;

namespace Automobile.Application.Services.Interfaces
{
    public interface IProprietarioService
    {
        Task<Proprietario> ObterProprietarioPeloId(Guid idProprietario);
        Task<Proprietario> ObterProprietarioPeloNumeroDocumento(Documento documento);
        PaginatedResult<ListaProprietarioResponse> ListarProprietarios(FiltroListaProprietariosRequest filtro);
    }
}
