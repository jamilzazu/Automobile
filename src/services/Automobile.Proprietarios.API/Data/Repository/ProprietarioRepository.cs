using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Automobile.Proprietarios.API.Models;
using Automobile.Core.Data;
using System;

namespace Automobile.Proprietarios.API.Data.Repository
{
    public class ProprietarioRepository : IProprietarioRepository
    {
        private readonly ProprietariosContext _context;

        public ProprietarioRepository(ProprietariosContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Proprietario>> ObterTodos()
        {
            return await _context.Proprietarios.AsNoTracking().ToListAsync();
        }

        public async Task<Proprietario> ObterPorDocumento(string documento)
        {
            return await _context.Proprietarios.FirstOrDefaultAsync(c => c.Documento.Numero == documento);
        }

        public async Task<Proprietario> ObterPorId(Guid id)
        {
            return await _context.Proprietarios.FindAsync(id);
        }

        public void Adicionar(Proprietario proprietario)
        {
            _context.Proprietarios.Add(proprietario);
        }

        public void Atualizar(Proprietario proprietario)
        {
            _context.Proprietarios.Update(proprietario);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}