using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

            // Data seed
            entity.HasData(
                // AppLanguageId: 1-English
                new TemplateEntryCategoryModel { Id = 1, Active = true, AppLanguageId = 1, Created = DateTime.Now, Description = "Fixed Incomings", EntryTypeId = 1, Updated = DateTime.Now },
                new TemplateEntryCategoryModel { Id = 2, Active = true, AppLanguageId = 1, Created = DateTime.Now, Description = "Variable Incomings", EntryTypeId = 1, Updated = DateTime.Now },
                new TemplateEntryCategoryModel { Id = 3, Active = true, AppLanguageId = 1, Created = DateTime.Now, Description = "Housing", EntryTypeId = 2, Updated = DateTime.Now },
                new TemplateEntryCategoryModel { Id = 4, Active = true, AppLanguageId = 1, Created = DateTime.Now, Description = "Health", EntryTypeId = 2, Updated = DateTime.Now },
                new TemplateEntryCategoryModel { Id = 5, Active = true, AppLanguageId = 1, Created = DateTime.Now, Description = "Transportation", EntryTypeId = 2, Updated = DateTime.Now },
                new TemplateEntryCategoryModel { Id = 6, Active = true, AppLanguageId = 1, Created = DateTime.Now, Description = "Personal", EntryTypeId = 2, Updated = DateTime.Now },
                new TemplateEntryCategoryModel { Id = 7, Active = true, AppLanguageId = 1, Created = DateTime.Now, Description = "Education", EntryTypeId = 2, Updated = DateTime.Now },
                new TemplateEntryCategoryModel { Id = 8, Active = true, AppLanguageId = 1, Created = DateTime.Now, Description = "Leisure", EntryTypeId = 2, Updated = DateTime.Now },
                new TemplateEntryCategoryModel { Id = 9, Active = true, AppLanguageId = 1, Created = DateTime.Now, Description = "Others", EntryTypeId = 2, Updated = DateTime.Now },

                // AppLanguageId: 1-Portuguese
                new TemplateEntryCategoryModel { Id = 10, Active = true, AppLanguageId = 2, Created = DateTime.Now, Description = "Receitas Fixas", EntryTypeId = 1, Updated = DateTime.Now },
                new TemplateEntryCategoryModel { Id = 11, Active = true, AppLanguageId = 2, Created = DateTime.Now, Description = "Receitas Variáveis", EntryTypeId = 1, Updated = DateTime.Now },
                new TemplateEntryCategoryModel { Id = 12, Active = true, AppLanguageId = 2, Created = DateTime.Now, Description = "Habitação", EntryTypeId = 2, Updated = DateTime.Now },
                new TemplateEntryCategoryModel { Id = 13, Active = true, AppLanguageId = 2, Created = DateTime.Now, Description = "Saúde", EntryTypeId = 2, Updated = DateTime.Now },
                new TemplateEntryCategoryModel { Id = 14, Active = true, AppLanguageId = 2, Created = DateTime.Now, Description = "Transporte", EntryTypeId = 2, Updated = DateTime.Now },
                new TemplateEntryCategoryModel { Id = 15, Active = true, AppLanguageId = 2, Created = DateTime.Now, Description = "Pessoais", EntryTypeId = 2, Updated = DateTime.Now },
                new TemplateEntryCategoryModel { Id = 16, Active = true, AppLanguageId = 2, Created = DateTime.Now, Description = "Educação", EntryTypeId = 2, Updated = DateTime.Now },
                new TemplateEntryCategoryModel { Id = 17, Active = true, AppLanguageId = 2, Created = DateTime.Now, Description = "Lazer", EntryTypeId = 2, Updated = DateTime.Now },
                new TemplateEntryCategoryModel { Id = 18, Active = true, AppLanguageId = 2, Created = DateTime.Now, Description = "Outras", EntryTypeId = 2, Updated = DateTime.Now }
            );
        }
    }
}
