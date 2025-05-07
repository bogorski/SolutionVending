using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPIVending.Model;

[PrimaryKey("Idtowaru", "IdzamowienieZewnetrzne")]
[Table("DostawaTowary")]
public partial class DostawaTowary
{
    [Key]
    [Column("IDTowaru")]
    public int Idtowaru { get; set; }

    [Key]
    [Column("IDZamowienieZewnetrzne")]
    public int IdzamowienieZewnetrzne { get; set; }

    public int Ilosc { get; set; }

    [StringLength(50)]
    public string? Opis { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataWaznosci { get; set; }

    public bool? IsActive { get; set; }

    [ForeignKey("Idtowaru")]
    [InverseProperty("DostawaTowaries")]
    public virtual Towary IdtowaruNavigation { get; set; } = null!;

    [ForeignKey("IdzamowienieZewnetrzne")]
    [InverseProperty("DostawaTowaries")]
    public virtual ZamowieniaZewnetrzne IdzamowienieZewnetrzneNavigation { get; set; } = null!;
}
