using Automobile.Core.Messages;
using Automobile.Proprietarios.Application.Queries.Interfaces;
using Automobile.Proprietarios.Application.Services.Interfaces;
using Automobile.Proprietarios.Domain.Repositories;

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
    }
}
