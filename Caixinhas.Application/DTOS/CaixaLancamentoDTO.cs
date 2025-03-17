using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Caixinhas.Application.DTOS;

public class CaixaLancamentoDTO
{
    public int IdCaixa { get; private set; }

    [Required(ErrorMessage = "O id usuario é necessario")]
    public int IdUsuarioLancamento { get; private set; }

    [Required(ErrorMessage = "O preço é necesario")]
    [Column(TypeName = "decimal(18,2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    public decimal Valor { get; private set; }

    [Required(ErrorMessage = "O descrição é necessario")]
    [MinLength(5)]
    [MaxLength(200)]
    public string Descricao { get; private set; } = string.Empty;

    public DateTime DataLamento { get; set; }
}
