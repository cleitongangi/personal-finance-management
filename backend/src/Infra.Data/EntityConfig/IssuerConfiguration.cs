using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infra.Data.EntityConfig
{
    public class IssuerConfiguration : IEntityTypeConfiguration<IssuerModel>
    {
        public void Configure(EntityTypeBuilder<IssuerModel> entity)
        {
            entity.ToTable("issuer");
            entity.HasKey(e => e.Id).HasName("issuer_pk");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn().HasColumnName("id");
            entity.Property(e => e.Created).HasColumnType("timestamp with time zone").HasColumnName("created");
            entity.Property(e => e.Description).HasMaxLength(255).HasColumnName("description");
            entity.Property(e => e.EntrySubcategoryId).HasColumnName("entry_subcategory_id");
            entity.Property(e => e.Updated).HasColumnType("timestamp with time zone").HasColumnName("updated");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.EntrySubcategory).WithMany(p => p.Issuers).HasForeignKey(d => d.EntrySubcategoryId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("issuer_fk_subcategory");
            entity.HasOne(d => d.User).WithMany(p => p.Issuers).HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("issuer_fk_user");
        }
    }
}
