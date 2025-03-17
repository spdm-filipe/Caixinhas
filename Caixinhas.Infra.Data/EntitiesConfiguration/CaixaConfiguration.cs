using Caixinhas.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Caixinhas.Infra.Data.EntitiesConfiguration;

public class CaixaConfiguration
{
    public void Configure(EntityTypeBuilder<Caixa> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Descricao).IsRequired().HasMaxLength(200);
        builder.Property(c => c.IdUsuario).IsRequired();
        builder.Property(c => c.ValorAtual).IsRequired(false);
        builder.Property(c => c.ValorMaximo).IsRequired();
        builder.Property(c => c.IsAtivo).IsRequired();
  
    }   
}
