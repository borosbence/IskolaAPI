using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IskolaAPI.Models
{
    [Index(nameof(nev), Name = "nev", IsUnique = true)]
    public partial class diakok
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string nev { get; set; }
        [Required]
        [StringLength(22)]
        public string email { get; set; }
        [Column(TypeName = "smallint(1)")]
        public short erdemjegy { get; set; }
    }
}
