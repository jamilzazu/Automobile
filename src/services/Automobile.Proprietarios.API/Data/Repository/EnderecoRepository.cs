using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Automobile.Proprietarios.API.Models;
using Automobile.Core.Data;
using System;

namespace Automobile.Proprietarios.API.Data.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly ProprietariosContext _context;

        public EnderecoRepository(ProprietariosContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Endereco> ObterPorProprietarioId(Guid proprietarioId)
        {
            return await _context.Enderecos.FirstOrDefaultAsync(c => c.ProprietarioId == proprietarioId);
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