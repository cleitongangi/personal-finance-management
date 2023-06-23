using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infra.Data.EntityConfig
{
    public class EntryTypeConfiguration : IEntityTypeConfiguration<EntryTypeModel>
    {
        public void Configure(EntityTypeBuilder<EntryTypeModel> entity)
        {
            entity.ToTable("entry_type");
            entity.HasKey(e => e.Id).HasName("entry_type_pk");

            entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("id");
            entity.Property(e => e.Description).HasMaxLength(255).HasColumnName("description");            

            entity.HasData(
                new EntryTypeModel { Id = 1, Description = "Incoming" },
                new EntryTypeModel { Id = 2, Description = "Expense" }
            );
        }
    }
}
