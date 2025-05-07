using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPIVending.Model;

[Table("ZamowieniaZewnetrzne")]
[Index("Idfaktury", Name = "IX_ZamowieniaZewnetrzne", IsUnique = true)]
public partial class ZamowieniaZewnetrzne
{
    [Key]
    [Column("IDZamowienieZewnetrzne")]
    public int IdzamowienieZewnetrzne { get; set; }

    [Column("IDMagazynu")]
    public int Idmagazynu { get; set; }

    [Column("IDDostawcy")]
    public int Iddostawcy { get; set; }

    [Column("IDFaktury")]
    public int Idfaktury { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Data { get; set; }

    [StringLength(50)]
    public string? Opis { get; set; }

    public bool? IsActive { get; set; }

    [InverseProperty("IdzamowienieZewnetrzneNavigation")]
    public virtual ICollection<DostawaTowary> DostawaTowaries { get; set; } = new List<DostawaTowary>();

    [ForeignKey("Iddostawcy")]
    [InverseProperty("ZamowieniaZewnetrznes")]
    public virtual Dostawcy IddostawcyNavigation { get; set; } = null!;

    [ForeignKey("Idfaktury")]
    [InverseProperty("ZamowieniaZewnetrzne")]
    public virtual Faktury IdfakturyNavigation { get; set; } = null!;

    [ForeignKey("Idmagazynu")]
    [InverseProperty("ZamowieniaZewnetrznes")]
    public virtual Magazyny IdmagazynuNavigation { get; set; } = null!;
}
