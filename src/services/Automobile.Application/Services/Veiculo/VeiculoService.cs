using Automobile.Core.Messages;
using Automobile.Database.SqlServer.Order;
using Automobile.Application.Queries.Request;
using Automobile.Application.Queries.Response;
using Automobile.Application.Services.Interfaces;
using Automobile.Domain.Entities;
using Automobile.Domain.Repositories;
using System;
using System.Threading.Tasks;
using Automobile.Application.Queries.Interfaces;

namespace Automobile.Application.Services
{
    public class VeiculoService : CommandHandler, IVeiculoService
    {
        private readonly IVeiculoQueries _veiculoQueries;
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoService(IVeiculoQueries veiculoQueries, IVeiculoRepository veiculoRepository)
        {
            _veiculoQueries = veiculoQueries;
            _veiculoRepository = veiculoRepository;
        }

        public Task<Veiculo> ObterVeiculoPeloNumeroRenavam(string renavam)
        {
            return _veiculoRepository.ObterVeiculoPeloNumeroRenavam(renavam);
        }

        public Task<Veiculo> ObterVeiculoPeloId(Guid id)
        {
            return _veiculoRepository.ObterVeiculoPeloId(id);
        }

        public PaginatedResult<ListaVeiculoResponse> ListarVeiculos(FiltroListaVeiculosRequest filtro)
        {
            return _veiculoQueries.ListarVeiculos(filtro);
        }
    }
}
