namespace Domain.Models
{
    public partial class EntryModel
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public short EntryTypeId { get; set; }

        public long IssuerId { get; set; }

        public decimal Value { get; set; }

        public string? Note { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public bool Active { get; set; }

        public virtual EntryTypeModel EntryType { get; set; } = null!;

        public virtual UserModel User { get; set; } = null!;
    }
}
