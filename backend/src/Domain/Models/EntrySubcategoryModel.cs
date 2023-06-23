namespace Domain.Models
{
    public partial class EntrySubcategoryModel
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public long CategoryId { get; set; }

        public string Description { get; set; } = null!;

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public bool Active { get; set; }

        public virtual EntryCategoryModel Category { get; set; } = null!;

        public virtual ICollection<IssuerModel> Issuers { get; set; } = new List<IssuerModel>();

        public virtual UserModel User { get; set; } = null!;
    }
}
