using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infra.Data.EntityConfig
{
    public class TemplateEntryCategoryConfiguration : IEntityTypeConfiguration<TemplateEntryCategoryModel>
    {
        public void Configure(EntityTypeBuilder<TemplateEntryCategoryModel> entity)
        {
            entity.ToTable("template_entry_category");
            entity.HasKey(e => e.Id).HasName("template_entry_category_pk");

            entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.AppLanguageId).HasColumnName("app_language_id");
            entity.Property(e => e.Created).HasColumnType("timestamp with time zone").HasColumnName("created");
            entity.Property(e => e.Description).HasMaxLength(255).HasColumnName("description");
            entity.Property(e => e.EntryTypeId).HasColumnName("entry_type_id");
            entity.Property(e => e.Updated).HasColumnType("timestamp with time zone").HasColumnName("updated");

            entity.HasOne(d => d.AppLanguage).WithMany(p => p.TemplateEntryCategories).HasForeignKey(d => d.AppLanguageId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("template_entry_category_fk_app_language");
            entity.HasOne(d => d.EntryType).WithMany(p => p.TemplateEntryCategories).HasForeignKey(d => d.EntryTypeId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("template_entry_category_fk_entry_type");
        }
    }
}
