using Automobile.Core.Messages;
using Automobile.Application.Services.Interfaces;
using Automobile.Domain.Entities;
using Automobile.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Automobile.Application.Services
{
    public class EnderecoService : CommandHandler, IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public Task<Endereco> ObterEnderecoPeloProprietarioId(Guid idProprietario)
        {
            return _enderecoRepository.ObterEnderecoPeloProprietarioId(idProprietario);
        }
    }
}
