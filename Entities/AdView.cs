using System.ComponentModel.DataAnnotations;

namespace WatchMate_API.Entities
{
    public class AdView
    {
        [Key]
        public int AdViewId { get; set; }

        public int UserId { get; set; }

        public int AdVideoId { get; set; }

        public decimal WatchedPercentage { get; set; }

        public bool RewardGiven { get; set; }

        public DateTime WatchedAt { get; set; }

        // Navigation
        public virtual Users User { get; set; }
        public virtual AdVideo AdVideo { get; set; }
    }
}
