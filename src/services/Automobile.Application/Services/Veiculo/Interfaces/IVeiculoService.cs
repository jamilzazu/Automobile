using System;
using System.Threading.Tasks;
using Automobile.Application.Queries.Request;
using Automobile.Application.Queries.Response;
using Automobile.Database.SqlServer.Order;
using Automobile.Domain.Entities;

namespace Automobile.Application.Services.Interfaces
{
    public interface IVeiculoService
    {
        Task<Veiculo> ObterVeiculoPeloId(Guid veiculoId);
        Task<Veiculo> ObterVeiculoPeloNumeroRenavam(string renavam);
        PaginatedResult<ListaVeiculoResponse> ListarVeiculos(FiltroListaVeiculosRequest filtro);
    }
}
