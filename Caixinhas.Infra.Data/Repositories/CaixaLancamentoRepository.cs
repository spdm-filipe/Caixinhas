using Caixinhas.Domain.Entities;
using Caixinhas.Domain.Interfaces;
using Caixinhas.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Caixinhas.Infra.Data.Repositories
{
    public class CaixaLancamentoRepository : ICaixaLancamentoRepository
    {

        ApplicationDbContext _context;

        public CaixaLancamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CaixaLancamento> Create(CaixaLancamento lancamento)
        {
            await _context.CaixaLancamentos.AddAsync(lancamento);
            await _context.SaveChangesAsync();
            return lancamento;
        }

        public async Task<IEnumerable<CaixaLancamento>> GetAllAsync(int idCaixa)
        {
            return await _context.CaixaLancamentos.Where(c => c.IdCaixa == idCaixa).ToListAsync();
        }

        public async Task<CaixaLancamento> GetByIdAsync(int idLancamento)
        {
            return await _context.CaixaLancamentos.FindAsync(idLancamento);
        }

        public async Task<CaixaLancamento> Remove(CaixaLancamento lancamento)
        {
            _context.CaixaLancamentos.Remove(lancamento);
            await _context.SaveChangesAsync();
            return lancamento;
        }

        public async Task<CaixaLancamento> Update(CaixaLancamento lancamento)
        {
             _context.CaixaLancamentos.Update(lancamento);
            await _context.SaveChangesAsync();
            return lancamento;  
        }
    }
}
