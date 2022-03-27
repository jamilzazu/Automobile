using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Automobile.Database.SqlServer.Order;
using Dapper;

namespace Automobile.Database.SqlServer.Extensions
{
    public static class DbConnectionExtensions
    {
        public static PaginatedResult<T> PaginatedQuery<T>(this IDbConnection connection, string sql,
            PaginateFilter filter) where T : class
        {
            var paginateSql = GetPaginateSql(sql, filter);
            return GetPaginatedResult<T>(connection, sql, filter, paginateSql);
        }

        private static PaginatedResult<T> GetPaginatedResult<T>(IDbConnection connection, string sql, PaginateFilter filter, StringBuilder paginateSql) where T : class
        {
            var queryResult = connection.QueryMultiple(paginateSql.ToString(), filter, commandTimeout: 6000);
            var countSql = $"SELECT COUNT(1) FROM ( {sql} ) c";
            var countResult = connection.ExecuteScalar<int>(countSql, filter, commandTimeout: 6000);

            List<T> data = queryResult.Read<T>().ToList();

            return new PaginatedResult<T>(filter.PageIndex, filter.PageSize, countResult, data);
        }

        private static StringBuilder GetPaginateSql(string sql, PaginateFilter filter)
        {
            filter.MaxPagSize = filter.MaxPagSize == 0 ? 100 : filter.MaxPagSize;
            filter.PageSize = (filter.PageSize > 0 && filter.PageSize <= filter.MaxPagSize) ? filter.PageSize : filter.MaxPagSize;
            filter.PageIndex = filter.PageIndex == 0 ? 1 : filter.PageIndex;

            int skip = (filter.PageIndex - 1) * filter.PageSize;
            int take = filter.PageSize;

            var paginateSql = new StringBuilder(sql);
            paginateSql.AppendLine(filter.GetOrderBy());
            paginateSql.AppendLine(filter.GetOffSet(skip, take));

            return paginateSql;
        }

        //public static async Task<IEnumerable<T>> QueryAuthorizedAsync<T>(this IDbConnection cnn, string sql, object param = null,
        //    IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        //{
        //    return await cnn.QueryAsync<T>(sql, param, transaction, commandTimeout, commandType);
        //}

        //public static async Task<IEnumerable<T>> QueryAuthorizedAsync<T>(this IDbConnection cnn, string sql, object param)
        //{
        //    return await cnn.QueryAsync<T>(sql, param);
        //}

        //public static async Task<T> QueryAuthorizedFirstOrDefaultAsync<T>(this IDbConnection cnn, string sql, object param = null,
        //    IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        //{
        //    return await cnn.QueryFirstOrDefaultAsync<T>(sql, param, transaction, commandTimeout, commandType);
        //}

    }
}