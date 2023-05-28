﻿using System.ComponentModel.DataAnnotations;

namespace MKTListNet.Domain.Entities
{
    public class EmailListModel
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = null!;

        [MaxLength(10)]
        public string Type { get; set; } = null!;
    }
}
