namespace Automobile.Database.SqlServer.Order
{
    public class OrderBy
    {
        public OrderBy(int idColumn, OrderType type)
        {
            IdColumn = idColumn;
            Type = type;
        }

        public OrderBy()
        {
        }

        public int IdColumn { get; set; }
        public OrderType Type { get; set; }
    }
}