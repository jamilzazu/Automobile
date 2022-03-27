using Automobile.Core.Messages;
using Automobile.Database.SqlServer.Order;
using Automobile.Application.Queries.Interfaces;
using Automobile.Application.Queries.Proprietario.Request;
using Automobile.Application.Queries.Response;
using Automobile.Application.Services.Interfaces;
using Automobile.Domain.Entities;
using Automobile.Domain.Entities.Objects;
using Automobile.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Automobile.Application.Services
{
    public class ProprietarioService : CommandHandler, IProprietarioService
    {
        private readonly IProprietarioQueries _proprietarioQueries;
        private readonly IProprietarioRepository _proprietarioRepository;

        public ProprietarioService(IProprietarioQueries proprietarioQueries, IProprietarioRepository proprietarioRepository)
        {
            _proprietarioQueries = proprietarioQueries;
            _proprietarioRepository = proprietarioRepository;
        }

        public Task<Proprietario> ObterProprietarioPeloNumeroDocumento(Documento documento)
        {
            return _proprietarioRepository.ObterProprietarioPeloNumeroDocumento(documento);
        }

        public Task<Proprietario> ObterProprietarioPeloId(Guid id)
        {
            return _proprietarioRepository.ObterProprietarioPeloId(id);
        }

        public PaginatedResult<ListaProprietarioResponse> ListarProprietarios(FiltroListaProprietariosRequest filtro)
        {
            return _proprietarioQueries.ListarProprietarios(filtro);
        }
    }
}
