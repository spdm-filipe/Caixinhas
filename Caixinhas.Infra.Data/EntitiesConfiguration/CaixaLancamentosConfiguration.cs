using Caixinhas.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Caixinhas.Infra.Data.EntitiesConfiguration;

public class CaixaLancamentosConfiguration
{
    public void Configure(EntityTypeBuilder<CaixaLancamento> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Descricao).IsRequired().HasMaxLength(200);
        builder.Property(c => c.Valor).IsRequired();
        builder.Property(c => c.DataLamento).IsRequired();
        builder.Property(c => c.IdUsuarioLancamento).IsRequired();
        builder.Property(c => c.IdCaixa).IsRequired();
        builder.HasOne(c => c.Caixa).WithMany(c => c.Lancamentos).HasForeignKey(c => c.IdCaixa);
    }


}
