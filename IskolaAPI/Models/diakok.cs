using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IskolaAPI.Models
{
    [Index("nev", Name = "nev", IsUnique = true)]
    public partial class diakok
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id { get; set; }
        [StringLength(50)]
        public string nev { get; set; } = null!;
        [StringLength(22)]
        public string email { get; set; } = null!;
        [Column(TypeName = "smallint(1)")]
        public short erdemjegy { get; set; }
    }
}
