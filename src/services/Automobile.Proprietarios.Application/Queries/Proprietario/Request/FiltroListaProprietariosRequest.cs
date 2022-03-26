using Automobile.Database.SqlServer.Order;

namespace Automobile.Proprietarios.Application.Queries.Proprietario.Request
{
    public class FiltroListaProprietariosRequest : PaginateFilter
    {
        private string _busca;

        public string Nome { get; set; }
        public string NumeroDocumento { get; set; }

        public string Busca
        {
            get => string.IsNullOrWhiteSpace(_busca) ? null : $"%{_busca.ToUpperInvariant()}%";
            set => _busca = value;
        }
    }
}
