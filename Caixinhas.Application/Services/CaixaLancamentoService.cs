using AutoMapper;
using Caixinhas.Application.DTOS;
using Caixinhas.Application.Interfaces;
using Caixinhas.Domain.Entities;
using Caixinhas.Domain.Interfaces;

namespace Caixinhas.Application.Services;

public class CaixaLancamentoService : ICaixaLancamentoService
{
    ICaixaLancamentoRepository _repository;
    IMapper _mapper;

    public CaixaLancamentoService(ICaixaLancamentoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Add(CaixaLancamentoDTO dto)
    {
        var caixaLancamento = _mapper.Map<CaixaLancamento>(dto);
        await _repository.Create(caixaLancamento);
    }

    public async Task<CaixaLancamentoDTO> GetCaixaLancamento(int? id)
    {
        var lancamento = await _repository.GetByIdAsync(id.Value);

        return _mapper.Map<CaixaLancamentoDTO>(lancamento);
    }

    public async Task<IEnumerable<CaixaLancamentoDTO>> GetCaixaLancamentos( int idCaixa)
    {
        var lancamentos = await _repository.GetAllAsync(idCaixa);

        return _mapper.Map<IEnumerable<CaixaLancamentoDTO>>(lancamentos);
    }

    public  async Task Remove(int id)
    {
        var caixa = await _repository.GetByIdAsync(id);
        if (caixa == null)
            throw new Exception("Lancamento da caixa não encontrados");

        await _repository.Remove(caixa);
    }

    public async Task Update(CaixaLancamentoDTO caixaLancamento)
    {
        var lancamento = _mapper.Map<CaixaLancamento>(caixaLancamento);
        if (lancamento == null)
            throw new Exception("Lancamento da caixa não encontrados");
        await _repository.Update(lancamento);
    }
}
