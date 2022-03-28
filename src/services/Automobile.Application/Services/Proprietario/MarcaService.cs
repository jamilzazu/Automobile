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
        private readonly IMarcaQueries _pmarcaQueries;
        private readonly IMarcaRepository _pmarcaRepository;

        public MarcaService(IMarcaQueries pmarcaQueries, IMarcaRepository pmarcaRepository)
        {
            _pmarcaQueries = pmarcaQueries;
            _pmarcaRepository = pmarcaRepository;
        }

        public Task<Marca> ObterMarcaPeloId(Guid id)
        {
            return _pmarcaRepository.ObterMarcaPeloId(id);
        }

        public PaginatedResult<ListaMarcaResponse> ListarMarcas(FiltroListaMarcasRequest filtro)
        {
            return _pmarcaQueries.ListarMarcas(filtro);
        }
    }
}
