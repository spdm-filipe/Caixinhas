using Caixinhas.Domain.Entities;

namespace Caixinhas.Domain.Interfaces;

public interface ICaixaLancamentoRepository
{
    Task<IEnumerable<CaixaLancamento>> GetAllAsync(int idCaixa);
    Task<CaixaLancamento> GetByIdAsync(int idLancamento);
    Task<CaixaLancamento> Create(CaixaLancamento lancamento);
    Task<CaixaLancamento> Update(CaixaLancamento lancamento);
    Task<CaixaLancamento> Remove(CaixaLancamento lancamento);

}
