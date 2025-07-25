﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WatchMate_API.Entities
{
    public class CustomerPackage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int PackageId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public bool IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }

        // Navigation
        [ForeignKey("CustomerId")]
        public virtual CustomerInfo CustomerInfo { get; set; }

        [ForeignKey("PackageId")]
        public virtual Package Package { get; set; }
    }
}
