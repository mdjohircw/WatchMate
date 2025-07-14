using System.ComponentModel.DataAnnotations;

namespace WatchMate_API.DTO.Settings
{
    public class CustomerPackageCreateDTO
    {
        [Required]

        public int CustomerId { get; set; }
        public int UserId { get; set; }

        [Required]
        public int PackageId { get; set; }

        public bool IsActive { get; set; } = true;

        
    }
}
