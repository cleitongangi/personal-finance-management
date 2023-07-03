using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infra.Data.EntityConfig
{
    public class EntryCategoryConfiguration : IEntityTypeConfiguration<EntryCategoryModel>
    {
        public void Configure(EntityTypeBuilder<EntryCategoryModel> entity)
        {
            entity.ToTable("entry_category");
            entity.HasKey(e => e.Id).HasName("entry_category_pk");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn().HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Created).HasColumnType("timestamp without time zone").HasColumnName("created");
            entity.Property(e => e.Description).HasMaxLength(255).HasColumnName("description");
            entity.Property(e => e.EntryTypeId).HasColumnName("entry_type_id");
            entity.Property(e => e.Updated).HasColumnType("timestamp without time zone").HasColumnName("updated");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.EntryType).WithMany(p => p.EntryCategories).HasForeignKey(d => d.EntryTypeId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("entry_category_fk_entry_type");
            entity.HasOne(d => d.User).WithMany(p => p.EntryCategories).HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("entry_category_fk_user");
        }
    }
}
