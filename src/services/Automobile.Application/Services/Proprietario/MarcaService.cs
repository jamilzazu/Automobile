using Automobile.Core.Messages;
using Automobile.Database.SqlServer.Order;
using Automobile.Application.Queries.Interfaces;
using Automobile.Application.Queries.Request;
using Automobile.Application.Queries.Response;
using Automobile.Application.Services.Interfaces;
using Automobile.Domain.Entities.Objects;
using Automobile.Domain.Repositories;
using System;
using System.Threading.Tasks;
using Automobile.Domain.Entitites;

namespace Automobile.Application.Services
{
    public class MarcaService : CommandHandler, IMarcaService
    {
        private readonly IMarcaQueries marcaQueries;
        private readonly IMarcaRepository marcaRepository;

        public MarcaService(IMarcaQueries pmarcaQueries, IMarcaRepository pmarcaRepository)
        {
            marcaQueries = pmarcaQueries;
            marcaRepository = pmarcaRepository;
        }

        public Task<Marca> ObterMarcaPeloId(Guid id)
        {
            return marcaRepository.ObterMarcaPeloId(id);
        }

        public Task<Marca> ObterMarcaPeloNome(string nome)
        {
            return marcaRepository.ObterMarcaPeloNome(nome);
        }

        public PaginatedResult<ListaMarcaResponse> ListarMarcas(FiltroListaMarcasRequest filtro)
        {
            return marcaQueries.ListarMarcas(filtro);
        }
    }
}
