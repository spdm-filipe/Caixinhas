using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caixinhas.Application.DTOS;

public class CaixaDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O valor atual é necessario")]
    [Column(TypeName = "decimal(18,2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    public decimal ValorAtual { get;   set; }

    [Required(ErrorMessage = "O valor maximo é necessario")]
    [Column(TypeName = "decimal(18,2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    public decimal ValorMaximo { get;   set; }
    public bool IsAtivo { get;   set; }

    [Required(ErrorMessage = "A descrição é necessaria")]
    [MinLength(5)]
    [MaxLength(200)]
    public string Descricao { get;   set; } = string.Empty;
    public DateTime Prazo { get;   set; }
    public int IdUsuario { get;   set; }
}
