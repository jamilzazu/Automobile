using Automobile.Core.Data;
using Automobile.Domain.Entitites;
using Automobile.Domain.Repositories;
using Automobile.Infra.EF.Configurations.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Automobile.Infra.EF
{

    public class MarcaRepository : IMarcaRepository
    {
        private readonly AutomobileContext _context;

        public MarcaRepository(AutomobileContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Marca> ObterMarcaPeloId(Guid id)
        {
            return await _context.Marcas.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Marca> ObterMarcaPeloNome(string nome)
        {
            return await _context.Marcas.FirstOrDefaultAsync(e => e.Nome == nome);
        }

        public void Adicionar(Marca marca)
        {
            _context.Marcas.Add(marca);
        }

        public void Atualizar(Marca marca)
        {
            _context.Marcas.Update(marca);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}