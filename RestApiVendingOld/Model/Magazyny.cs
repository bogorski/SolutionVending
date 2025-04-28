using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApiVending.Model;

[Table("Magazyny")]
public partial class Magazyny
{
    [Key]
    [Column("IDMagazynu")]
    public int Idmagazynu { get; set; }

    [StringLength(50)]
    public string Nazwa { get; set; } = null!;

    [StringLength(50)]
    public string Ulica { get; set; } = null!;

    [StringLength(50)]
    public string Miasto { get; set; } = null!;

    [StringLength(10)]
    public string KodPocztowy { get; set; } = null!;

    [StringLength(50)]
    public string Kraj { get; set; } = null!;

    [StringLength(50)]
    public string? Opis { get; set; }

    [InverseProperty("IdmagazynuNavigation")]
    public virtual ICollection<MagazynTowary> MagazynTowaries { get; set; } = new List<MagazynTowary>();

    [InverseProperty("IdmagazynuNavigation")]
    public virtual ICollection<Zamowienia> Zamowienia { get; set; } = new List<Zamowienia>();

    [InverseProperty("IdmagazynuNavigation")]
    public virtual ICollection<ZamowieniaZewnetrzne> ZamowieniaZewnetrznes { get; set; } = new List<ZamowieniaZewnetrzne>();
}
