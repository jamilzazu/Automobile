using Automobile.Core.Helpers;
using Automobile.Proprietarios.Application.Queries.Interfaces;
using System.Data;
using Automobile.Proprietarios.Application.Queries.Proprietario.Request;
using Automobile.Proprietarios.Application.Queries.Response;
using Automobile.Database.SqlServer.Extensions;
using Automobile.Database.SqlServer.Order;

namespace Automobile.Proprietarios.Domain.Queries
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
            var sql = GetType().Assembly.GetScript("ListaProprietario.sql");

            if (!string.IsNullOrWhiteSpace(filtro.Busca))
            {
                sql += $" AND (Nome LIKE @Busca OR Documento LIKE @Busca )";
            }

            return _dbConnection.PaginatedQuery<ListaProprietarioResponse>(sql, filtro);
        }
    }
}
