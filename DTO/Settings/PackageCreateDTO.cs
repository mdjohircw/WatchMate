﻿using System.ComponentModel.DataAnnotations;

namespace WatchMate_API.DTO.Settings
{
    public class PackageCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string? PackageName { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int? ValidityDays { get; set; }

        public int? MaxDailyViews { get; set; }

        public decimal? PerAdReward { get; set; }

        [Required]
        public byte? IsActive { get; set; }
        public int? UserId { get; set; }
    }
}
