using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPIVend.Model;

[Table("Towary")]
public partial class Towary
{
    [Key]
    [Column("IDTowaru")]
    public int Idtowaru { get; set; }

    [StringLength(50)]
    public string Nazwa { get; set; } = null!;

    [StringLength(50)]
    public string JednostkaMiary { get; set; } = null!;

    [StringLength(50)]
    public string Producent { get; set; } = null!;

    [StringLength(50)]
    public string? KodKreskowy { get; set; }

    [StringLength(50)]
    public string? Wymiary { get; set; }

    [StringLength(50)]
    public string? Opis { get; set; }

    public bool? IsActive { get; set; }

    [InverseProperty("IdtowaruNavigation")]
    public virtual ICollection<DostawaTowary> DostawaTowaries { get; set; } = new List<DostawaTowary>();

    [InverseProperty("IdtowaruNavigation")]
    public virtual ICollection<MagazynTowary> MagazynTowaries { get; set; } = new List<MagazynTowary>();

    [InverseProperty("IdtowaruNavigation")]
    public virtual ICollection<MaszynaTowary> MaszynaTowaries { get; set; } = new List<MaszynaTowary>();

    [InverseProperty("IdtowaruNavigation")]
    public virtual ICollection<PracownikTowary> PracownikTowaries { get; set; } = new List<PracownikTowary>();

    [InverseProperty("IdtowaruNavigation")]
    public virtual ICollection<Transakcje> Transakcjes { get; set; } = new List<Transakcje>();

    [InverseProperty("IdtowaruNavigation")]
    public virtual ICollection<ZamowienieTowary> ZamowienieTowaries { get; set; } = new List<ZamowienieTowary>();
}
