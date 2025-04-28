using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApiVending.Model;

[Table("Pracownicy")]
public partial class Pracownicy
{
    [Key]
    [Column("IDPracownika")]
    public int Idpracownika { get; set; }

    [StringLength(50)]
    public string Imie { get; set; } = null!;

    [StringLength(50)]
    public string Nazwisko { get; set; } = null!;

    [Column("IDStanowiskaPracy")]
    public int IdstanowiskaPracy { get; set; }

    [Column(TypeName = "money")]
    public decimal Pensja { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DataZatrudnienia { get; set; }

    [Column("IDPojazdu")]
    public int? Idpojazdu { get; set; }

    [Column("IDTrasy")]
    public int? Idtrasy { get; set; }

    [StringLength(50)]
    public string? Opis { get; set; }

    [ForeignKey("Idpojazdu")]
    [InverseProperty("Pracownicies")]
    public virtual Pojazdy? IdpojazduNavigation { get; set; }

    [ForeignKey("IdstanowiskaPracy")]
    [InverseProperty("Pracownicies")]
    public virtual StanowiskaPracy IdstanowiskaPracyNavigation { get; set; } = null!;

    [ForeignKey("Idtrasy")]
    [InverseProperty("Pracownicies")]
    public virtual Trasy? IdtrasyNavigation { get; set; }

    [InverseProperty("IdpracownikaNavigation")]
    public virtual ICollection<PracownikTowary> PracownikTowaries { get; set; } = new List<PracownikTowary>();

    [InverseProperty("IdpracownikaNavigation")]
    public virtual ICollection<Wizyty> Wizyties { get; set; } = new List<Wizyty>();

    [InverseProperty("IdpracownikaNavigation")]
    public virtual ICollection<Zamowienia> Zamowienia { get; set; } = new List<Zamowienia>();
}
