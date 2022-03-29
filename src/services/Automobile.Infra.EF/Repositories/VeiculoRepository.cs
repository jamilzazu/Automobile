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

    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly AutomobileContext _context;

        public VeiculoRepository(AutomobileContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;


        public async Task<Veiculo> ObterVeiculoPeloId(Guid id)
        {
            return await _context.Veiculos.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Veiculo> ObterVeiculoPeloNumeroRenavam(string renavam)
        {
            return await _context.Veiculos.FirstOrDefaultAsync(e => e.Renavam == renavam);
        }

        public void Adicionar(Veiculo veiculo)
        {
            _context.Veiculos.Add(veiculo);
        }

        public void Atualizar(Veiculo veiculo)
        {
            _context.Veiculos.Update(veiculo);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}