using Automobile.Core.Helpers;
using System.Data;
using Automobile.Application.Queries.Request;
using Automobile.Application.Queries.Response;
using Automobile.Database.SqlServer.Extensions;
using Automobile.Database.SqlServer.Order;
using Automobile.Application.Queries.Interfaces;

namespace Automobile.Domain.Queries
{
    public class VeiculoQueries : IVeiculoQueries
    {
        private readonly IDbConnection _dbConnection;

        public VeiculoQueries(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public PaginatedResult<ListaVeiculoResponse> ListarVeiculos(FiltroListaVeiculosRequest filtro)
        {
            var sql = GetType().Assembly.GetScript("ListaVeiculos.sql");

            if (!string.IsNullOrWhiteSpace(filtro.Busca))
            {
                sql += $" AND (Renavam LIKE @Busca )";
            }

            return _dbConnection.PaginatedQuery<ListaVeiculoResponse>(sql, filtro);
        }
    }
}
