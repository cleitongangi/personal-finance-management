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
            entity.Property(e => e.Created).HasColumnType("timestamp without time zone").HasColumnName("created");
            entity.Property(e => e.Description).HasMaxLength(255).HasColumnName("description");
            entity.Property(e => e.Updated).HasColumnType("timestamp without time zone").HasColumnName("updated");

            entity.HasOne(d => d.AppLanguage).WithMany(p => p.TemplateEntrySubcategories).HasForeignKey(d => d.AppLanguageId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("template_entry_subcategory_fk_app_language");
            entity.HasOne(d => d.Category).WithMany(p => p.TemplateEntrySubcategories).HasForeignKey(d => d.CategoryId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("template_entry_subcategory_fk_category");

            // Data seed
            entity.HasData(
            #region AppLanguageId: 1-English
                // Category: 1-Fixed Incomings
                new TemplateEntrySubcategoryModel { Id = 1, Active = true, AppLanguageId = 1, CategoryId = 1, Created = DateTime.Now, Description = "Salary", Updated = DateTime.Now },
                // Category: 2-Variable Incomings
                new TemplateEntrySubcategoryModel { Id = 2, Active = true, AppLanguageId = 1, CategoryId = 2, Created = DateTime.Now, Description = "Extras", Updated = DateTime.Now },
                // Category: 3-Housing
                new TemplateEntrySubcategoryModel { Id = 3, Active = true, AppLanguageId = 1, CategoryId = 3, Created = DateTime.Now, Description = "Rental", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 4, Active = true, AppLanguageId = 1, CategoryId = 3, Created = DateTime.Now, Description = "Condominium fee", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 5, Active = true, AppLanguageId = 1, CategoryId = 3, Created = DateTime.Now, Description = "Other fees", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 6, Active = true, AppLanguageId = 1, CategoryId = 3, Created = DateTime.Now, Description = "Energy", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 7, Active = true, AppLanguageId = 1, CategoryId = 3, Created = DateTime.Now, Description = "Water", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 8, Active = true, AppLanguageId = 1, CategoryId = 3, Created = DateTime.Now, Description = "Gas", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 9, Active = true, AppLanguageId = 1, CategoryId = 3, Created = DateTime.Now, Description = "Phones", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 10, Active = true, AppLanguageId = 1, CategoryId = 3, Created = DateTime.Now, Description = "Internet", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 11, Active = true, AppLanguageId = 1, CategoryId = 3, Created = DateTime.Now, Description = "Supermarket", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 12, Active = true, AppLanguageId = 1, CategoryId = 3, Created = DateTime.Now, Description = "Employees", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 13, Active = true, AppLanguageId = 1, CategoryId = 3, Created = DateTime.Now, Description = "Others", Updated = DateTime.Now },
                // Category: 4-Health
                new TemplateEntrySubcategoryModel { Id = 14, Active = true, AppLanguageId = 1, CategoryId = 4, Created = DateTime.Now, Description = "Health insurance", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 15, Active = true, AppLanguageId = 1, CategoryId = 4, Created = DateTime.Now, Description = "Expense with doctors", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 16, Active = true, AppLanguageId = 1, CategoryId = 4, Created = DateTime.Now, Description = "Dentist", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 17, Active = true, AppLanguageId = 1, CategoryId = 4, Created = DateTime.Now, Description = "Drugstore", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 18, Active = true, AppLanguageId = 1, CategoryId = 6, Created = DateTime.Now, Description = "Academy", Updated = DateTime.Now },
                // Category: 5-Transportation
                new TemplateEntrySubcategoryModel { Id = 19, Active = true, AppLanguageId = 1, CategoryId = 5, Created = DateTime.Now, Description = "Taxes and Fees", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 20, Active = true, AppLanguageId = 1, CategoryId = 5, Created = DateTime.Now, Description = "Insurance", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 21, Active = true, AppLanguageId = 1, CategoryId = 5, Created = DateTime.Now, Description = "Fuel", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 22, Active = true, AppLanguageId = 1, CategoryId = 5, Created = DateTime.Now, Description = "Parking", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 23, Active = true, AppLanguageId = 1, CategoryId = 5, Created = DateTime.Now, Description = "Washing", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 24, Active = true, AppLanguageId = 1, CategoryId = 5, Created = DateTime.Now, Description = "Maintenance", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 25, Active = true, AppLanguageId = 1, CategoryId = 5, Created = DateTime.Now, Description = "Traffic ticket", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 26, Active = true, AppLanguageId = 1, CategoryId = 5, Created = DateTime.Now, Description = "Taxi", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 27, Active = true, AppLanguageId = 1, CategoryId = 5, Created = DateTime.Now, Description = "Toll", Updated = DateTime.Now },
                // Category: 6-Personal
                new TemplateEntrySubcategoryModel { Id = 28, Active = true, AppLanguageId = 1, CategoryId = 6, Created = DateTime.Now, Description = "Personal Hygiene (nails, waxing, etc.)", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 29, Active = true, AppLanguageId = 1, CategoryId = 6, Created = DateTime.Now, Description = "Hairdresser", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 30, Active = true, AppLanguageId = 1, CategoryId = 6, Created = DateTime.Now, Description = "Clothing", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 31, Active = true, AppLanguageId = 1, CategoryId = 6, Created = DateTime.Now, Description = "Other Purchases", Updated = DateTime.Now },
                // Category: 7-Education
                new TemplateEntrySubcategoryModel { Id = 32, Active = true, AppLanguageId = 1, CategoryId = 7, Created = DateTime.Now, Description = "School / College", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 33, Active = true, AppLanguageId = 1, CategoryId = 7, Created = DateTime.Now, Description = "Courses", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 34, Active = true, AppLanguageId = 1, CategoryId = 7, Created = DateTime.Now, Description = "Languages ​​course", Updated = DateTime.Now },
                // Category: 8-Leisure
                new TemplateEntrySubcategoryModel { Id = 35, Active = true, AppLanguageId = 1, CategoryId = 7, Created = DateTime.Now, Description = "Restaurants", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 36, Active = true, AppLanguageId = 1, CategoryId = 7, Created = DateTime.Now, Description = "Fast food", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 37, Active = true, AppLanguageId = 1, CategoryId = 7, Created = DateTime.Now, Description = "Games", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 38, Active = true, AppLanguageId = 1, CategoryId = 7, Created = DateTime.Now, Description = "Tours", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 39, Active = true, AppLanguageId = 1, CategoryId = 7, Created = DateTime.Now, Description = "Trips", Updated = DateTime.Now },
                // Category: 9-Others
                new TemplateEntrySubcategoryModel { Id = 40, Active = true, AppLanguageId = 1, CategoryId = 7, Created = DateTime.Now, Description = "Donations / Tithes / Offerings", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 41, Active = true, AppLanguageId = 1, CategoryId = 7, Created = DateTime.Now, Description = "Gifts", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 42, Active = true, AppLanguageId = 1, CategoryId = 7, Created = DateTime.Now, Description = "Others", Updated = DateTime.Now },
            #endregion AppLanguageId: 1-English

            #region AppLanguageId: 2-Portuguese
                // Category: 10-Receitas Fixas
                new TemplateEntrySubcategoryModel { Id = 43, Active = true, AppLanguageId = 2, CategoryId = 10, Created = DateTime.Now, Description = "Salário", Updated = DateTime.Now },
                // Category: 11-Receitas Variáveis
                new TemplateEntrySubcategoryModel { Id = 44, Active = true, AppLanguageId = 2, CategoryId = 11, Created = DateTime.Now, Description = "Extras", Updated = DateTime.Now },
                // Category: 12-Habitação
                new TemplateEntrySubcategoryModel { Id = 45, Active = true, AppLanguageId = 2, CategoryId = 12, Created = DateTime.Now, Description = "Aluguel", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 46, Active = true, AppLanguageId = 2, CategoryId = 12, Created = DateTime.Now, Description = "Condomínio", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 47, Active = true, AppLanguageId = 2, CategoryId = 12, Created = DateTime.Now, Description = "IPTU / Taxas", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 48, Active = true, AppLanguageId = 2, CategoryId = 12, Created = DateTime.Now, Description = "Energia", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 49, Active = true, AppLanguageId = 2, CategoryId = 12, Created = DateTime.Now, Description = "Água", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 51, Active = true, AppLanguageId = 2, CategoryId = 12, Created = DateTime.Now, Description = "Gás", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 52, Active = true, AppLanguageId = 2, CategoryId = 12, Created = DateTime.Now, Description = "Telefone", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 53, Active = true, AppLanguageId = 2, CategoryId = 12, Created = DateTime.Now, Description = "Internet", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 54, Active = true, AppLanguageId = 2, CategoryId = 12, Created = DateTime.Now, Description = "Supermercado", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 55, Active = true, AppLanguageId = 2, CategoryId = 12, Created = DateTime.Now, Description = "Empregados", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 56, Active = true, AppLanguageId = 2, CategoryId = 12, Created = DateTime.Now, Description = "Outros", Updated = DateTime.Now },

                // Category: 13-Saúde
                new TemplateEntrySubcategoryModel { Id = 57, Active = true, AppLanguageId = 2, CategoryId = 13, Created = DateTime.Now, Description = "Plano de Saúde", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 58, Active = true, AppLanguageId = 2, CategoryId = 13, Created = DateTime.Now, Description = "Médicos", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 59, Active = true, AppLanguageId = 2, CategoryId = 13, Created = DateTime.Now, Description = "Dentista", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 61, Active = true, AppLanguageId = 2, CategoryId = 13, Created = DateTime.Now, Description = "Drogaria", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 62, Active = true, AppLanguageId = 2, CategoryId = 13, Created = DateTime.Now, Description = "Academia", Updated = DateTime.Now },
                // Category: 14-Transporte
                new TemplateEntrySubcategoryModel { Id = 63, Active = true, AppLanguageId = 2, CategoryId = 14, Created = DateTime.Now, Description = "IPVA / Seguro Obrigatório / Licenciamento", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 64, Active = true, AppLanguageId = 2, CategoryId = 14, Created = DateTime.Now, Description = "Seguro", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 65, Active = true, AppLanguageId = 2, CategoryId = 14, Created = DateTime.Now, Description = "Comnbustível", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 66, Active = true, AppLanguageId = 2, CategoryId = 14, Created = DateTime.Now, Description = "Estacionamentos", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 67, Active = true, AppLanguageId = 2, CategoryId = 14, Created = DateTime.Now, Description = "Lavagens", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 68, Active = true, AppLanguageId = 2, CategoryId = 14, Created = DateTime.Now, Description = "Mecânico/Manutenções", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 69, Active = true, AppLanguageId = 2, CategoryId = 14, Created = DateTime.Now, Description = "Multas", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 70, Active = true, AppLanguageId = 2, CategoryId = 14, Created = DateTime.Now, Description = "Taxi", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 71, Active = true, AppLanguageId = 2, CategoryId = 14, Created = DateTime.Now, Description = "Pedágios", Updated = DateTime.Now },
                // Category: 15-Pessoais
                new TemplateEntrySubcategoryModel { Id = 72, Active = true, AppLanguageId = 2, CategoryId = 15, Created = DateTime.Now, Description = "Higiene Pessoal (unha, depilação etc.)", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 73, Active = true, AppLanguageId = 2, CategoryId = 15, Created = DateTime.Now, Description = "Cabeleireiro", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 74, Active = true, AppLanguageId = 2, CategoryId = 15, Created = DateTime.Now, Description = "Vestuário", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 75, Active = true, AppLanguageId = 2, CategoryId = 15, Created = DateTime.Now, Description = "Demais Compras", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 76, Active = true, AppLanguageId = 2, CategoryId = 15, Created = DateTime.Now, Description = "Outros/Não identificado", Updated = DateTime.Now },
                // Category: 16-Educação
                new TemplateEntrySubcategoryModel { Id = 77, Active = true, AppLanguageId = 2, CategoryId = 16, Created = DateTime.Now, Description = "Escola / Faculdade", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 78, Active = true, AppLanguageId = 2, CategoryId = 16, Created = DateTime.Now, Description = "Cursos", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 79, Active = true, AppLanguageId = 2, CategoryId = 16, Created = DateTime.Now, Description = "Curso de Idiomas", Updated = DateTime.Now },
                // Category: 17-Lazer
                new TemplateEntrySubcategoryModel { Id = 80, Active = true, AppLanguageId = 2, CategoryId = 17, Created = DateTime.Now, Description = "Restaurantes", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 81, Active = true, AppLanguageId = 2, CategoryId = 17, Created = DateTime.Now, Description = "Fast food", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 82, Active = true, AppLanguageId = 2, CategoryId = 17, Created = DateTime.Now, Description = "Games", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 83, Active = true, AppLanguageId = 2, CategoryId = 17, Created = DateTime.Now, Description = "Passeios", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 84, Active = true, AppLanguageId = 2, CategoryId = 17, Created = DateTime.Now, Description = "Viagens", Updated = DateTime.Now },
                // Category: 18-Outras
                new TemplateEntrySubcategoryModel { Id = 85, Active = true, AppLanguageId = 2, CategoryId = 18, Created = DateTime.Now, Description = "Doações / dízimos / ofertas", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 86, Active = true, AppLanguageId = 2, CategoryId = 18, Created = DateTime.Now, Description = "Presentes", Updated = DateTime.Now },
                new TemplateEntrySubcategoryModel { Id = 87, Active = true, AppLanguageId = 2, CategoryId = 18, Created = DateTime.Now, Description = "Others", Updated = DateTime.Now }
            #endregion AppLanguageId: 2-Portuguese
            );
        }
    }
}
