using Automobile.Core.Data;
using Automobile.Domain.Entities;
using Automobile.Domain.Repositories;
using Automobile.Infra.EF.Configurations.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Automobile.Enderecos.Infra.EF
{

    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly AutomobileContext _context;

        public EnderecoRepository(AutomobileContext context)
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