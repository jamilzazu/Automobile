using Automobile.Database.SqlServer.Order;

namespace Automobile.Application.Queries.Request
{
    public class FiltroListaVeiculosRequest : PaginateFilter
    {
        private string _busca;

        public string Renavam { get; set; }

        public string Busca
        {
            get => string.IsNullOrWhiteSpace(_busca) ? null : $"%{_busca.ToUpperInvariant()}%";
            set => _busca = value;
        }
    }
}
