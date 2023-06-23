namespace Domain.Models
{
    public partial class EntryCategoryModel
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public short EntryTypeId { get; set; }

        public string Description { get; set; } = null!;

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<EntrySubcategoryModel> EntrySubcategories { get; set; } = new List<EntrySubcategoryModel>();

        public virtual EntryTypeModel EntryType { get; set; } = null!;

        public virtual UserModel User { get; set; } = null!;
    }
}
