using System.ComponentModel.DataAnnotations;

namespace WatchMate_API.Entities
{
    public class Referral
    {
        [Key]
        public int ReferralId { get; set; }

        public int ReferrerId { get; set; }
        public int ReferredUserId { get; set; }

        public decimal BonusAmount { get; set; }

        public int ReferralLevel { get; set; } // 1 for direct, 2 for second level

        public DateTime CreatedAt { get; set; }

        // Navigation
        public virtual Users Referrer { get; set; }
        public virtual Users ReferredUser { get; set; }
    }
}
