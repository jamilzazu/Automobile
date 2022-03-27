using Automobile.Core.Messages;
using Automobile.Proprietarios.Application.Services.Interfaces;
using Automobile.Proprietarios.Domain.Entities;
using Automobile.Proprietarios.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Automobile.Proprietarios.Application.Services
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
