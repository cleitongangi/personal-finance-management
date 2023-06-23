using Domain.Models;
using Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
    public class PersonalFinanceDbContext : DbContext
    {
        public virtual DbSet<AppLanguageModel> AppLanguages { get; set; }
        public virtual DbSet<BalanceModel> Balances { get; set; }
        public virtual DbSet<EntryModel> Entries { get; set; }
        public virtual DbSet<EntryCategoryModel> EntryCategories { get; set; }
        public virtual DbSet<EntrySubcategoryModel> EntrySubcategories { get; set; }
        public virtual DbSet<EntryTypeModel> EntryTypes { get; set; }
        public virtual DbSet<IssuerModel> Issuers { get; set; }
        public virtual DbSet<TemplateEntryCategoryModel> TemplateEntryCategories { get; set; }
        public virtual DbSet<TemplateEntrySubcategoryModel> TemplateEntrySubcategories { get; set; }
        public virtual DbSet<UserModel> Users { get; set; }

        public PersonalFinanceDbContext(DbContextOptions<PersonalFinanceDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new AppLanguageConfiguration());
            modelBuilder.ApplyConfiguration(new BalanceConfiguration());
            modelBuilder.ApplyConfiguration(new EntryCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new EntryConfiguration());
            modelBuilder.ApplyConfiguration(new EntrySubcategoryConfiguration());
            modelBuilder.ApplyConfiguration(new EntryTypeConfiguration());
            modelBuilder.ApplyConfiguration(new IssuerConfiguration());
            modelBuilder.ApplyConfiguration(new TemplateEntryCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TemplateEntrySubcategoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
