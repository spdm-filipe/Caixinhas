using Caixinhas.Domain.Entities;
using Caixinhas.Domain.Interfaces;
using Caixinhas.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Caixinhas.Infra.Data.Repositories
{
    public class CaixaRepository : ICaixaRepository
    {
        ApplicationDbContext _context;

        public CaixaRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Caixa> Create(Caixa caixa)
        {
            await _context.AddAsync(caixa);
            await _context.SaveChangesAsync();
            return caixa;
        }

        public async Task Delete(int id)
        {
            var caixa = await _context.Caixas.FindAsync(id);
            if (caixa == null)
                throw new Exception("Caixa não encontrada");
            

            caixa.Delete();
            _context.Caixas.Update(caixa);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Caixa>> GetAllAsync()
        {
            var caixas = await _context.Caixas.AsNoTracking().ToListAsync();

            return caixas;
        }

        public async Task<Caixa> GetByIdAsync(int id)
        {
           return await _context.Caixas.FindAsync(id);  
        }

        public async Task<Caixa> GetByNomeAsync(string nome)
        {
            return await _context.Caixas.FirstOrDefaultAsync(c => c.Descricao.Contains(nome));
        }

        public async Task<Caixa> Update(Caixa caixa)
        {
             _context.Caixas.Update(caixa);
            await _context.SaveChangesAsync();
            return caixa;
        }
    }
}
