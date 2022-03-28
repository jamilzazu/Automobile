using Automobile.Core.Helpers;
using Automobile.Application.Queries.Interfaces;
using System.Data;
using Automobile.Application.Queries.Request;
using Automobile.Application.Queries.Response;
using Automobile.Database.SqlServer.Extensions;
using Automobile.Database.SqlServer.Order;

namespace Automobile.Domain.Queries
{
    public class ProprietarioQueries : IProprietarioQueries
    {
        private readonly IDbConnection _dbConnection;

        public ProprietarioQueries(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public PaginatedResult<ListaProprietarioResponse> ListarProprietarios(FiltroListaProprietariosRequest filtro)
        {
            var sql = GetType().Assembly.GetScript("ListaProprietarios.sql");

            if (!string.IsNullOrWhiteSpace(filtro.Busca))
            {
                sql += $" AND (UPPER(Nome) LIKE @Busca OR Documento LIKE @Busca )";
            }

            return _dbConnection.PaginatedQuery<ListaProprietarioResponse>(sql, filtro);
        }
    }
}
