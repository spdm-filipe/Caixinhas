namespace Caixinhas.Domain.Entities;

public class CaixaLancamento : Entity
{
    public int IdCaixa { get; private set; }
    public int IdUsuarioLancamento { get; private set; }
    public decimal Valor { get; private set; }
    public string Descricao { get; private set; } = string.Empty;
    public bool IsExcluido { get; private set; }


}
