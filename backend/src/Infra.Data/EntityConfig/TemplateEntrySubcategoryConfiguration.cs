using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infra.Data.EntityConfig
{
    public class TemplateEntrySubcategoryConfiguration : IEntityTypeConfiguration<TemplateEntrySubcategoryModel>
    {
        public void Configure(EntityTypeBuilder<TemplateEntrySubcategoryModel> entity)
        {
            entity.ToTable("template_entry_subcategory");
            entity.HasKey(e => e.Id).HasName("template_entry_subcategory_pk");

            entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.AppLanguageId).HasColumnName("app_language_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Created).HasColumnType("timestamp with time zone").HasColumnName("created");
            entity.Property(e => e.Description).HasMaxLength(255).HasColumnName("description");
            entity.Property(e => e.Updated).HasColumnType("timestamp with time zone").HasColumnName("updated");

            entity.HasOne(d => d.AppLanguage).WithMany(p => p.TemplateEntrySubcategories).HasForeignKey(d => d.AppLanguageId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("template_entry_subcategory_fk_app_language");
            entity.HasOne(d => d.Category).WithMany(p => p.TemplateEntrySubcategories).HasForeignKey(d => d.CategoryId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("template_entry_subcategory_fk_category");
        }
    }
}
