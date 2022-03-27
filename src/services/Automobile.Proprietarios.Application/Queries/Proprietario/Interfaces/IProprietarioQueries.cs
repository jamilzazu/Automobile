using Automobile.Database.SqlServer.Order;
using Automobile.Proprietarios.Application.Queries.Proprietario.Request;
using Automobile.Proprietarios.Application.Queries.Response;

namespace Automobile.Proprietarios.Application.Queries.Interfaces
{
    public interface IProprietarioQueries
    {
        PaginatedResult<ListaProprietarioResponse> ListarProprietarios(FiltroListaProprietariosRequest filtro);
    }
}
