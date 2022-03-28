using Automobile.Database.SqlServer.Order;
using Automobile.Application.Queries.Response;
using Automobile.Application.Queries.Request;

namespace Automobile.Application.Queries.Interfaces
{
    public interface IMarcaQueries
    {
        PaginatedResult<ListaMarcaResponse> ListarMarcas(FiltroListaMarcasRequest filtro);
    }
}
