using Automobile.Core.Helpers;
using Automobile.Application.Queries.Interfaces;
using System.Data;
using Automobile.Application.Queries.Response;
using Automobile.Database.SqlServer.Extensions;
using Automobile.Database.SqlServer.Order;
using Automobile.Application.Queries.Request;

namespace Automobile.Domain.Queries
{
    public class MarcaQueries : IMarcaQueries
    {
        private readonly IDbConnection _dbConnection;

        public MarcaQueries(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public PaginatedResult<ListaMarcaResponse> ListarMarcas(FiltroListaMarcasRequest filtro)
        {
            var sql = GetType().Assembly.GetScript("ListaMarcas.sql");

            if (!string.IsNullOrWhiteSpace(filtro.Busca))
            {
                sql += $" AND UPPER(Nome) LIKE @Busca ";
            }

            return _dbConnection.PaginatedQuery<ListaMarcaResponse>(sql, filtro);
        }
    }
}
