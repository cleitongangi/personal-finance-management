using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infra.Data.EntityConfig
{
    public class EntrySubcategoryConfiguration : IEntityTypeConfiguration<EntrySubcategoryModel>
    {
        public void Configure(EntityTypeBuilder<EntrySubcategoryModel> entity)
        {
            entity.ToTable("entry_subcategory");
            entity.HasKey(e => e.Id).HasName("entry_subcategory_pk");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn().HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Created).HasColumnType("timestamp without time zone").HasColumnName("created");
            entity.Property(e => e.Description).HasMaxLength(255).HasColumnName("description");
            entity.Property(e => e.Updated).HasColumnType("timestamp without time zone").HasColumnName("updated");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Category).WithMany(p => p.EntrySubcategories).HasForeignKey(d => d.CategoryId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("entry_subcategory_fk_category");
            entity.HasOne(d => d.User).WithMany(p => p.EntrySubcategories).HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("entry_subcategory_fk_user");
        }
    }
}
