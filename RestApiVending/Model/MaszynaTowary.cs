using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApiVending.Model;

[PrimaryKey("NumerMaszyny", "Idtowaru")]
[Table("MaszynaTowary")]
public partial class MaszynaTowary
{
    [Key]
    [StringLength(10)]
    public string NumerMaszyny { get; set; } = null!;

    [Key]
    [Column("IDTowaru")]
    public int Idtowaru { get; set; }

    public int Stan { get; set; }

    [StringLength(50)]
    public string? Opis { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? Data { get; set; }

    [ForeignKey("Idtowaru")]
    [InverseProperty("MaszynaTowaries")]
    public virtual Towary IdtowaruNavigation { get; set; } = null!;

    [ForeignKey("NumerMaszyny")]
    [InverseProperty("MaszynaTowaries")]
    public virtual Maszyny NumerMaszynyNavigation { get; set; } = null!;
}
