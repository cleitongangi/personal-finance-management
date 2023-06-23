namespace Domain.Models
{
    public partial class IssuerModel
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public long EntrySubcategoryId { get; set; }

        public string Description { get; set; } = null!;

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public virtual EntrySubcategoryModel EntrySubcategory { get; set; } = null!;

        public virtual UserModel User { get; set; } = null!;
    }
}
