using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infra.Data.EntityConfig
{
    public class BalanceConfiguration : IEntityTypeConfiguration<BalanceModel>
    {
        public void Configure(EntityTypeBuilder<BalanceModel> entity)
        {
            entity.ToTable("balance");
            entity.HasKey(e => e.UserId).HasName("balance_pk");

            entity.Property(e => e.UserId).ValueGeneratedNever().HasColumnName("user_id");
            entity.Property(e => e.Balance1).HasPrecision(12, 2).HasColumnName("balance");
            entity.Property(e => e.Created).HasColumnType("timestamp without time zone").HasColumnName("created");
            entity.Property(e => e.ReferenceMonth).HasMaxLength(6).IsFixedLength().HasComment("Information with format YYYYMM").HasColumnName("reference_month");
            entity.Property(e => e.Updated).HasColumnType("timestamp without time zone").HasColumnName("updated");
            entity.HasOne(d => d.User).WithOne(p => p.Balance).HasForeignKey<BalanceModel>(d => d.UserId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("balance_fk_user");
        }
    }
}
