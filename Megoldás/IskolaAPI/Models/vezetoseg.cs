using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IskolaAPI.Models
{
    [Index(nameof(id), nameof(email), Name = "id", IsUnique = true)]
    public partial class vezetoseg
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string nev { get; set; }
        [Required]
        [StringLength(50)]
        public string email { get; set; }
        [Required]
        [StringLength(50)]
        public string megbizas { get; set; }
    }
}
