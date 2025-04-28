using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPIVend.Model;

[PrimaryKey("IdLokalizacji", "NumerMaszyny")]
[Table("LokalizacjaMaszyny")]
[Index("NumerMaszyny", Name = "IX_LokalizacjaMaszyny_NumerMaszyny", IsUnique = true)]
[Index("NumerMaszyny", Name = "UC_LokalizacjaMaszyny_NumerMaszyny", IsUnique = true)]
public partial class LokalizacjaMaszyny
{
    [Key]
    public int IdLokalizacji { get; set; }

    [Key]
    [StringLength(10)]
    public string NumerMaszyny { get; set; } = null!;

    public bool? IsActive { get; set; }

    [ForeignKey("IdLokalizacji")]
    [InverseProperty("LokalizacjaMaszynies")]
    public virtual Lokalizacje IdLokalizacjiNavigation { get; set; } = null!;

    [ForeignKey("NumerMaszyny")]
    [InverseProperty("LokalizacjaMaszyny")]
    public virtual Maszyny NumerMaszynyNavigation { get; set; } = null!;
}
