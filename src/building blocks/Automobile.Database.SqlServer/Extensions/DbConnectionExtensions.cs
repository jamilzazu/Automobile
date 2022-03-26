using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Automobile.Database.SqlServer.Order;
using Dapper;

namespace Automobile.Database.SqlServer.Extensions
{
    public static class DbConnectionExtensions
    {
        public static async Task<PaginatedResult<T>> PaginatedQueryAsync<T>(this IDbConnection connection, string sql,
            PaginateFilter filter) where T : class
        {
            var paginateSql = GetPaginateSql(sql, filter);
            return await GetPaginatedResultAsync<T>(connection, sql, filter, paginateSql);
        }

        public static async Task<PaginatedResult<T>> PaginatedQueryAuthorizedAsync<T>(this IDbConnection connection, string sql, PaginateFilter paginateFilter
            ) where T : class
        {

            return await PaginatedQueryAsync<T>(connection, sql, paginateFilter);
        }

        public static async Task<IEnumerable<T>> QueryAuthorizedAsync<T>(this IDbConnection cnn, string sql, object param = null,
            IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await cnn.QueryAsync<T>(sql, param, transaction, commandTimeout, commandType);
        }

        public static async Task<IEnumerable<T>> QueryAuthorizedAsync<T>(this IDbConnection cnn, string sql, object param)
        {
            return await cnn.QueryAsync<T>(sql, param);
        }

        public static async Task<T> QueryAuthorizedFirstOrDefaultAsync<T>(this IDbConnection cnn, string sql, object param = null,
            IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return await cnn.QueryFirstOrDefaultAsync<T>(sql, param, transaction, commandTimeout, commandType);
        }

        private static async Task<PaginatedResult<T>> GetPaginatedResultAsync<T>(IDbConnection connection, string sql, PaginateFilter filter, StringBuilder paginateSql) where T : class
        {
            var queryResult = connection.QueryAsync<T>(paginateSql.ToString(), filter, commandTimeout: 6000);
            var countSql = $"SELECT COUNT(1) FROM ( {sql} )";
            var countResult = connection.QueryFirstAsync<int>(countSql, filter, commandTimeout: 6000);
            var data = await queryResult.ConfigureAwait(false);
            var count = await countResult.ConfigureAwait(false);

            return new PaginatedResult<T>(filter.PageIndex, filter.PageSize, count, data);
        }

        private static StringBuilder GetPaginateSql(string sql, PaginateFilter filter)
        {
            var paginateSql = new StringBuilder("SELECT * FROM ( SELECT a.*, (ROW_NUMBER() OVER (ORDER BY DataCadastro DESC)) as Row FROM (");
            paginateSql.AppendLine(sql);
            paginateSql.AppendLine(filter.GetOrderBy());
            paginateSql.AppendLine(") a WHERE Row BETWEEN(@PageIndex -1) * @PageSize + 1 AND(((@PageIndex -1) * @PageSize + 1) + @PageSize) - 1");

            //var paginateSql = new StringBuilder("SELECT * FROM ( SELECT a.*, rownum r__ FROM (");
            //paginateSql.AppendLine(sql);
            //paginateSql.AppendLine(filter.GetOrderBy());
            //paginateSql.AppendLine(") a WHERE rownum < ((@PageIndex * @PageSize) + 1 )) WHERE r__ >= (((@PageIndex -1) * @PageSize) + 1)");

            return paginateSql;
        }
    }
}