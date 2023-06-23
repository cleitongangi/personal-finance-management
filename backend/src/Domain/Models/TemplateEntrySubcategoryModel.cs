namespace Domain.Models
{
    public partial class TemplateEntrySubcategoryModel
    {
        public int Id { get; set; }

        public short AppLanguageId { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; } = null!;

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public bool Active { get; set; }

        public virtual AppLanguageModel AppLanguage { get; set; } = null!;

        public virtual TemplateEntryCategoryModel Category { get; set; } = null!;
    }
}
