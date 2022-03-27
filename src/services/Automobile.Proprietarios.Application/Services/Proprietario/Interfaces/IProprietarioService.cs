using Automobile.Database.SqlServer.Order;
using Automobile.Proprietarios.Application.Queries.Proprietario.Request;
using Automobile.Proprietarios.Application.Queries.Response;
using Automobile.Proprietarios.Domain.Entities;
using Automobile.Proprietarios.Domain.Entities.Objects;
using System;
using System.Threading.Tasks;

namespace Automobile.Proprietarios.Application.Services.Interfaces
{
    public interface IProprietarioService
    {
        Task<Proprietario> ObterProprietarioPeloId(Guid idProprietario);
        Task<Proprietario> ObterProprietarioPeloNumeroDocumento(Documento documento);
        PaginatedResult<ListaProprietarioResponse> ListarProprietarios(FiltroListaProprietariosRequest filtro);
    }
}
