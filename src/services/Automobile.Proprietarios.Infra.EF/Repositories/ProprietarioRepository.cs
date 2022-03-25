using Automobile.Core.Data;
using Automobile.Proprietarios.Domain.Entities;
using Automobile.Proprietarios.Domain.Entities.Objects;
using Automobile.Proprietarios.Domain.Repositories;
using Automobile.Proprietarios.Infra.EF.Configurations.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Automobile.Proprietarios.Infra.EF
{

    public class ProprietarioRepository : IProprietarioRepository
    {
        private readonly ProprietariosContext _context;

        public ProprietarioRepository(ProprietariosContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;


        public async Task<Proprietario> ObterProprietarioPeloNumeroDocumento(Documento documento)
        {
            return await _context.Proprietarios.FirstOrDefaultAsync(c => c.Documento.NumeroDocumento == documento.NumeroDocumento);
        }

        public async Task<Proprietario> ObterProprietarioPeloId(Guid id)
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

        Proprietario IProprietarioRepository.Adicionar(Proprietario proprietario)
        {
            return _context.Proprietarios.Add(proprietario).Entity;
        }

        Proprietario IProprietarioRepository.Atualizar(Proprietario proprietario)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Proprietario> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}