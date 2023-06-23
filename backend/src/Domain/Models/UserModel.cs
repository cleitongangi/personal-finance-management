namespace Domain.Models
{
    public partial class UserModel
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Email { get; set; } = null!;

        public DateTime Created { get; set; }

        public TimeOnly Updated { get; set; }

        public bool Active { get; set; }

        public virtual BalanceModel? Balance { get; set; }

        public virtual ICollection<EntryModel> Entries { get; set; } = new List<EntryModel>();

        public virtual ICollection<EntryCategoryModel> EntryCategories { get; set; } = new List<EntryCategoryModel>();

        public virtual ICollection<EntrySubcategoryModel> EntrySubcategories { get; set; } = new List<EntrySubcategoryModel>();

        public virtual ICollection<IssuerModel> Issuers { get; set; } = new List<IssuerModel>();
    }
}
