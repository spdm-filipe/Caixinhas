using Caixinhas.Application.DTOS;

namespace Caixinhas.Application.Interfaces;

public interface ICaixaService
{
    Task<IEnumerable<CaixaDTO>> GetCaixas();
    Task<CaixaDTO> GetCaixa(int? id);
    Task Add(CaixaDTO caixa);
    Task Update(CaixaDTO caixa);
    Task Remove(int? id);
}
