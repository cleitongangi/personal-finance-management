using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infra.Data.EntityConfig
{
    public class UserConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> entity)
        {
            entity.ToTable("user");
            entity.HasKey(e => e.Id).HasName("user_pk");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn().HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Created).HasColumnType("timestamp without time zone").HasColumnName("created");
            entity.Property(e => e.Email).HasMaxLength(255).HasColumnName("email");
            entity.Property(e => e.Name).HasMaxLength(255).HasColumnName("name");
            entity.Property(e => e.Password).HasMaxLength(255).HasColumnName("password");
            entity.Property(e => e.Updated).HasColumnName("updated");
            entity.Property(e => e.UserName).HasMaxLength(255).HasColumnName("user_name");
        }
    }
}
