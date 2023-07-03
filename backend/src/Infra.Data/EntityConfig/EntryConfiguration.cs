using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infra.Data.EntityConfig
{
    public class EntryConfiguration : IEntityTypeConfiguration<EntryModel>
    {
        public void Configure(EntityTypeBuilder<EntryModel> entity)
        {
            entity.ToTable("entry");
            entity.HasKey(e => e.Id).HasName("entry_pk");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn().HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Created).HasColumnType("timestamp without time zone").HasColumnName("created");
            entity.Property(e => e.EntryDate).HasColumnType("timestamp without time zone").HasColumnName("entry_date");
            entity.Property(e => e.EntryTypeId).HasColumnName("entry_type_id");
            entity.Property(e => e.IssuerId).HasColumnName("issuer_id");
            entity.Property(e => e.Note).HasMaxLength(4000).HasColumnName("note");
            entity.Property(e => e.Updated).HasColumnType("timestamp without time zone").HasColumnName("updated");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Value).HasPrecision(12, 2).HasColumnName("value");

            entity.HasOne(d => d.EntryType).WithMany(p => p.Entries).HasForeignKey(d => d.EntryTypeId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("entry_fk_entry_type");
            entity.HasOne(d => d.User).WithMany(p => p.Entries).HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("entry_fk_user");
        }
    }
}
