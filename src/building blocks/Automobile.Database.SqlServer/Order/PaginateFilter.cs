using System.Linq;

namespace Automobile.Database.SqlServer.Order
{
    public class PaginateFilter
    {
        public int MaxPagSize { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public OrderBy[] OrderBy { get; set; }

        public string GetOrderBy()
        {
            var orderBy = OrderBy?.Length > 0 ? string.Join(", ", OrderBy.Select(c => $"{(c.IdColumn == 0 ? 1 : c.IdColumn)} {c.Type}")) : "1";

            return $" ORDER BY {orderBy}";
        }

        public static string GetOffSet(int skip, int take)
        {
            return $" OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY";
        }
    }
}