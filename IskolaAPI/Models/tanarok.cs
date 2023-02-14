using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IskolaAPI.Models
{
    [Index("email", Name = "email", IsUnique = true)]
    public partial class tanarok
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id { get; set; }
        [StringLength(50)]
        public string nev { get; set; } = null!;
        [StringLength(50)]
        public string email { get; set; } = null!;
        [StringLength(20)]
        public string tantargy { get; set; } = null!;
    }
}
