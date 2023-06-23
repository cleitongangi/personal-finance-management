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

            // Data seed
            entity.HasData(
                // # AppLanguageId: 1-English
                // Category: 1-Fixed Incomings
                new TemplateEntrySubcategoryModel { Id = 1, Active = true, AppLanguageId = 1, CategoryId = 1, Created = DateTime.Now, Description = "", Updated = DateTime.Now },


                // AppLanguageId: 2-Portuguese
                // Category: 10-Receitas Fixas
                new TemplateEntrySubcategoryModel { Id = 2, Active = true, AppLanguageId = 1, CategoryId = 10, Created = DateTime.Now, Description = "Renda", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 3, Active = true, AppLanguageId = 1, CategoryId = 10, Created = DateTime.Now, Description = "Extras", Updated = DateTime.Now },
                // Category: 11-Receitas Variáveis
                new TemplateEntrySubcategoryModel { Id = 4, Active = true, AppLanguageId = 1, CategoryId = 10, Created = DateTime.Now, Description = "Extras", Updated = DateTime.Now }

            );
        }
    }
}
