namespace Domain.Models
{
    public partial class EntryTypeModel
    {
        public short Id { get; set; }

        public string Description { get; set; } = null!;

        public virtual ICollection<EntryModel> Entries { get; set; } = new List<EntryModel>();

        public virtual ICollection<EntryCategoryModel> EntryCategories { get; set; } = new List<EntryCategoryModel>();

        public virtual ICollection<TemplateEntryCategoryModel> TemplateEntryCategories { get; set; } = new List<TemplateEntryCategoryModel>();
    }
}
