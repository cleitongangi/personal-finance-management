namespace Domain.Models
{
    public partial class AppLanguageModel
    {
        public short Id { get; set; }

        public string Description { get; set; } = null!;

        public bool IsDefault { get; set; }

        public virtual ICollection<TemplateEntryCategoryModel> TemplateEntryCategories { get; set; } = new List<TemplateEntryCategoryModel>();

        public virtual ICollection<TemplateEntrySubcategoryModel> TemplateEntrySubcategories { get; set; } = new List<TemplateEntrySubcategoryModel>();
    }
}
