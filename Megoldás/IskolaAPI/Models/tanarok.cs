using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IskolaAPI.Models
{
    [Index(nameof(email), Name = "email", IsUnique = true)]
    public partial class tanarok
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
        [StringLength(20)]
        public string tantargy { get; set; }
    }
}
