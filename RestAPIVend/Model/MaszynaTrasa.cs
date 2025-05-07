using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPIVend.Model;

[PrimaryKey("Idtrasy", "MaszynaId")]
[Table("MaszynaTrasa")]
public partial class MaszynaTrasa
{
    [Key]
    [Column("IDTrasy")]
    public int Idtrasy { get; set; }

    public bool? IsActive { get; set; }

    [Key]
    [Column("maszyna_id")]
    public int MaszynaId { get; set; }

    [ForeignKey("Idtrasy")]
    [InverseProperty("MaszynaTrasas")]
    public virtual Trasy IdtrasyNavigation { get; set; } = null!;

    [ForeignKey("MaszynaId")]
    [InverseProperty("MaszynaTrasas")]
    public virtual Maszyny Maszyna { get; set; } = null!;
}
