using System;

namespace Domain.Models
{
    public partial class BalanceModel
    {
        public long UserId { get; set; }

        /// <summary>
        /// Information with format YYYYMM
        /// </summary>
        public string ReferenceMonth { get; set; } = null!;

        public decimal Balance1 { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public virtual UserModel User { get; set; } = null!;
    }
}
