using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApiVending.Model;

[PrimaryKey("Idmagazynu", "Idtowaru")]
[Table("MagazynTowary")]
public partial class MagazynTowary
{
    [Key]
    [Column("IDMagazynu")]
    public int Idmagazynu { get; set; }

    [Key]
    [Column("IDTowaru")]
    public int Idtowaru { get; set; }

    public int Stan { get; set; }

    [StringLength(50)]
    public string? Opis { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? Data { get; set; }

    [ForeignKey("Idmagazynu")]
    [InverseProperty("MagazynTowaries")]
    public virtual Magazyny IdmagazynuNavigation { get; set; } = null!;

    [ForeignKey("Idtowaru")]
    [InverseProperty("MagazynTowaries")]
    public virtual Towary IdtowaruNavigation { get; set; } = null!;
}
