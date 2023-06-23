namespace Domain.Models
{
    public partial class TemplateEntryCategoryModel
    {
        public int Id { get; set; }

        public short AppLanguageId { get; set; }

        public short EntryTypeId { get; set; }

        public string Description { get; set; } = null!;

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public bool Active { get; set; }

        public virtual AppLanguageModel AppLanguage { get; set; } = null!;

        public virtual EntryTypeModel EntryType { get; set; } = null!;

        public virtual ICollection<TemplateEntrySubcategoryModel> TemplateEntrySubcategories { get; set; } = new List<TemplateEntrySubcategoryModel>();
    }
}
