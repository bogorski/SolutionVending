using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPIVend.Model;

public partial class Zamowienia
{
    [Key]
    [Column("IDZamowienia")]
    public int Idzamowienia { get; set; }

    [Column("IDMagazynu")]
    public int Idmagazynu { get; set; }

    [Column("IDPracownika")]
    public int Idpracownika { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Data { get; set; }

    [StringLength(50)]
    public string? Priorytet { get; set; }

    [StringLength(50)]
    public string? Opis { get; set; }

    public bool? IsActive { get; set; }

    [ForeignKey("Idmagazynu")]
    [InverseProperty("Zamowienia")]
    public virtual Magazyny IdmagazynuNavigation { get; set; } = null!;

    [ForeignKey("Idpracownika")]
    [InverseProperty("Zamowienia")]
    public virtual Pracownicy IdpracownikaNavigation { get; set; } = null!;

    [InverseProperty("IdzamowieniaNavigation")]
    public virtual ICollection<ZamowienieTowary> ZamowienieTowaries { get; set; } = new List<ZamowienieTowary>();
}
