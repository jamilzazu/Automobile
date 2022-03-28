using Automobile.Database.SqlServer.Order;
using Automobile.Application.Queries.Request;
using Automobile.Application.Queries.Response;
using System;
using System.Threading.Tasks;
using Automobile.Domain.Entitites;

namespace Automobile.Application.Services.Interfaces
{
    public interface IMarcaService
    {
        Task<Marca> ObterMarcaPeloId(Guid idProprietario);
        PaginatedResult<ListaMarcaResponse> ListarMarcas(FiltroListaMarcasRequest filtro);
    }
}
