using Caixinhas.Domain.Entities;

namespace Caixinhas.Domain.Interfaces;

public interface ICaixaRepository
{
  Task<IEnumerable<Caixa>> GetAllAsync();

  Task<Caixa> GetByIdAsync(int id);

  Task<Caixa> GetByNomeAsync(string nome);

  Task<Caixa> Create(Caixa caixa);

  Task<Caixa> Update(Caixa caixa);

  Task Delete(int id);

}
