using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPIVend.Model;

[PrimaryKey("NumerMaszyny", "Idtrasy")]
[Table("MaszynaTrasa")]
public partial class MaszynaTrasa
{
    [Key]
    [StringLength(10)]
    public string NumerMaszyny { get; set; } = null!;

    [Key]
    [Column("IDTrasy")]
    public int Idtrasy { get; set; }

    public bool? IsActive { get; set; }

    [ForeignKey("Idtrasy")]
    [InverseProperty("MaszynaTrasas")]
    public virtual Trasy IdtrasyNavigation { get; set; } = null!;

    [ForeignKey("NumerMaszyny")]
    [InverseProperty("MaszynaTrasas")]
    public virtual Maszyny NumerMaszynyNavigation { get; set; } = null!;
}
