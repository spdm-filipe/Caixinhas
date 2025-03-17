using Caixinhas.Application.DTOS;

namespace Caixinhas.Application.Interfaces;

public interface ICaixaLancamentoService
{
    Task<IEnumerable<CaixaLancamentoDTO>> GetCaixaLancamentos(int idCaixa);
    Task<CaixaLancamentoDTO> GetCaixaLancamento(int? id);
    Task Add(CaixaLancamentoDTO caixaLancamento);
    Task Update(CaixaLancamentoDTO caixaLancamento);
    Task Remove(int id);
}
