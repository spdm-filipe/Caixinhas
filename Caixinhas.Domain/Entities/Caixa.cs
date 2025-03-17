using Caixinhas.Domain.Validation;
using System.Drawing;

namespace Caixinhas.Domain.Entities;

public class Caixa : Entity
{
    public decimal ValorAtual { get; private set; }
    public decimal ValorMaximo { get; private set; }
    public bool IsAtivo { get; private set; }
    public string  Descricao { get; private set; } =string.Empty;
    public DateTime Prazo { get; private set; }
    public int IdUsuario { get; private set; }

    public Caixa(int idUsuario, decimal valorAtual, decimal valorMaximo,
        string descricao, DateTime prazo)
    {
        ValidateDomin(valorAtual, valorMaximo, descricao, prazo);
        IdUsuario = idUsuario;
    }
    public void Update(int valorAtual, int valorMaximo, string descricao,
        string prazo)
    {
        ValidateDomin(valorAtual, valorMaximo, descricao, prazo);
    }

    private void ValidateDomin(decimal valorAtual, decimal valorMaximo, string descricao,
       DateTime prazo)
    {
        DomainExceptionValidation.When(valorAtual < 0, "Valor atual inválido");
        DomainExceptionValidation.When(valorMaximo < 0, " Valor máximo inválido");
        DomainExceptionValidation.When(descricao.Length > 200, "Descrição inválida");
        DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "Descrição inválida");
        DomainExceptionValidation.When(prazo < DateTime.Now, "Prazo inválido");

        Descricao = descricao;
        ValorAtual = valorAtual;
        ValorMaximo = valorMaximo;
        Prazo = prazo;

    }
}
