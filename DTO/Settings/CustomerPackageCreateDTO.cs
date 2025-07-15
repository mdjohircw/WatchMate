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

        public  byte Status { get; set; }

        public int? PayMethodID { get; set; }
        public string? TransctionCode { get; set; }


    }
}
