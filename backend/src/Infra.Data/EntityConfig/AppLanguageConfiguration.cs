using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infra.Data.EntityConfig
{
    public class AppLanguageConfiguration : IEntityTypeConfiguration<AppLanguageModel>
    {
        public void Configure(EntityTypeBuilder<AppLanguageModel> entity)
        {
            entity.ToTable("app_language");
            entity.HasKey(e => e.Id).HasName("app_language_pk");

            entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("id");
            entity.Property(e => e.Description).HasMaxLength(255).HasColumnName("description");
            entity.Property(e => e.IsDefault).HasColumnName("is_default");
        }
    }
}
