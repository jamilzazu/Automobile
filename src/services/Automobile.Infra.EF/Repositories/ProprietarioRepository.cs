using Automobile.Core.Data;
using Automobile.Domain.Entities;
using Automobile.Domain.Entities.Objects;
using Automobile.Domain.Repositories;
using Automobile.Infra.EF.Configurations.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Automobile.Infra.EF
{

    public class ProprietarioRepository : IProprietarioRepository
    {
        private readonly ProprietariosContext _context;

        public ProprietarioRepository(ProprietariosContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;


        public Task<Proprietario> ObterProprietarioPeloNumeroDocumento(Documento documento)
        {
            return _context.Proprietarios.FirstOrDefaultAsync(c => c.Documento.NumeroDocumento == documento.NumeroDocumento);
        }

        public async Task<Proprietario> ObterProprietarioPeloId(Guid id)
        {
            return await _context.Proprietarios.FirstOrDefaultAsync(e => e.Id == id);
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