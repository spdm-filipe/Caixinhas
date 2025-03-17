using AutoMapper;
using Caixinhas.Application.DTOS;
using Caixinhas.Application.Interfaces;
using Caixinhas.Domain.Entities;
using Caixinhas.Domain.Interfaces;

namespace Caixinhas.Application.Services;

public class CaixaService : ICaixaService
{

    ICaixaRepository _caixaRepository;
    IMapper _mapper;

    public CaixaService(ICaixaRepository caixaRepository, IMapper maper)
    {
        _mapper = maper;
        _caixaRepository = caixaRepository ?? throw new ArgumentNullException(nameof(caixaRepository));
    }
    public async Task<IEnumerable<CaixaDTO>> GetCaixas()
    {
        var caixas = await _caixaRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<CaixaDTO>>(caixas);
    }
    public async Task<CaixaDTO> GetCaixa(int? id)
    {
       var caixa = await _caixaRepository.GetByIdAsync(id.Value);
        return _mapper.Map<CaixaDTO>(caixa);
    }

    public async Task Add(CaixaDTO caixaDto)
    {
        var caixa = _mapper.Map<Caixa>(caixaDto);

        await _caixaRepository.Create(caixa);
    }

    public async Task Remove(int? id)
    {
        var caixa = _caixaRepository.GetByIdAsync(id.Value);
        if (caixa == null)
            throw new Exception("Caixa não encontrada");
        
        await _caixaRepository.Delete(id.Value);
    }

    public async Task Update(CaixaDTO caixaDto)
    {
        var caixa = _mapper.Map<Caixa>(caixaDto);
        if (caixa == null)
            throw new Exception("Caixa não encontrada");
        
        await _caixaRepository.Update(caixa);   
    }
}
