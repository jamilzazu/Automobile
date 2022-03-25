using Automobile.Core.Messages;
using Automobile.Proprietarios.Application.Queries.Interfaces;
using Automobile.Proprietarios.Application.Services.Interfaces;
using Automobile.Proprietarios.Domain.Entities;
using Automobile.Proprietarios.Domain.Entities.Objects;
using Automobile.Proprietarios.Domain.Repositories;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace Automobile.Proprietarios.Application.Services
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

        public async Task<bool> ExisteCpfJaCadastrado(Documento documento)
        {
            var proprietario = await _proprietarioQueries.ObterProprietarioPeloNumeroDocumento(documento);

            return proprietario != null;
        }
    }
}
