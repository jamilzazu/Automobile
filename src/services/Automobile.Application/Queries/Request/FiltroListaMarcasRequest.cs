using Automobile.Database.SqlServer.Order;

namespace Automobile.Application.Queries.Request
{
    public class FiltroListaMarcasRequest : PaginateFilter
    {
        private string _busca;

        public string Nome { get; set; }

        public string Busca
        {
            get => string.IsNullOrWhiteSpace(_busca) ? null : $"%{_busca.ToUpperInvariant()}%";
            set => _busca = value;
        }
    }
}
