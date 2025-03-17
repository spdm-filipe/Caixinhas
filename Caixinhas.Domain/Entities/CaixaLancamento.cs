using Caixinhas.Domain.Validation;

namespace Caixinhas.Domain.Entities;

public class CaixaLancamento : Entity
{
    public int IdCaixa { get; private set; }
    public Caixa Caixa { get; set; }
    public int IdUsuarioLancamento { get; private set; }
    public decimal Valor { get; private set; }
    public string Descricao { get; private set; } = string.Empty;
    public DateTime DataLamento { get; set; }

    public void Update(int idCaixa, int idUsuario, decimal valor,
        string descricao)
    {
        ValidateDomin(idCaixa, idUsuario, Valor, descricao);
    }

    private void ValidateDomin(int idCaixa, int idUsuario, decimal valor,
        string descricao)
    {
        DomainExceptionValidation.When(idCaixa < 0, "Id do caixa inválido");
        DomainExceptionValidation.When(idUsuario < 0, "Id do usuário inválido");
        DomainExceptionValidation.When(valor <= 0, "Valor inválido");
        DomainExceptionValidation.When(descricao.Length > 200, "Descrição inválida");
        DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "Descrição inválida");

        Descricao = descricao;
        IdCaixa = idCaixa;
        IdUsuarioLancamento = idUsuario;
        Valor = valor;
    }
 

}
