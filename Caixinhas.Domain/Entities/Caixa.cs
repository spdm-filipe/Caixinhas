namespace Caixinhas.Domain.Entities;

public class Caixa : Entity
{
    public decimal ValorAtual { get; private set; }
    public decimal ValorMaximo { get; private set; }
    public bool IsAtivo { get; private set; }
    public string  Descricao { get; private set; } =string.Empty;
    public DateTime Prazo { get; private set; }
    public int IdUsuarioDono { get; private set; }



}
