using Automobile.Core.Data;
using Automobile.Proprietarios.Domain.Entities;
using Automobile.Proprietarios.Domain.Repositories;
using Automobile.Proprietarios.Infra.EF.Configurations.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Automobile.Enderecos.Infra.EF
{

    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly ProprietariosContext _context;

        public EnderecoRepository(ProprietariosContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Endereco> ObterEnderecoPeloProprietarioId(Guid proprietarioId)
        {
            return await _context.Enderecos.FirstOrDefaultAsync(e => e.ProprietarioId == proprietarioId);
        }

        public void Adicionar(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
        }

        public void Atualizar(Endereco endereco)
        {
            _context.Enderecos.Update(endereco);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}