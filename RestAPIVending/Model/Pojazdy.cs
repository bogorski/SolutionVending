using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPIVending.Model;

[Table("Pojazdy")]
public partial class Pojazdy
{
    [Key]
    [Column("IDPojazdu")]
    public int Idpojazdu { get; set; }

    [StringLength(50)]
    public string Marka { get; set; } = null!;

    [StringLength(10)]
    public string NumerRejestracyjny { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime DataPrzegladu { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DataUbezpieczenia { get; set; }

    [Column("IDWarsztatu")]
    public int? Idwarsztatu { get; set; }

    [StringLength(50)]
    public string? Opis { get; set; }

    [StringLength(50)]
    public string? Usterki { get; set; }

    public bool? IsActive { get; set; }

    [ForeignKey("Idwarsztatu")]
    [InverseProperty("Pojazdies")]
    public virtual Warsztaty? IdwarsztatuNavigation { get; set; }

    [InverseProperty("IdpojazduNavigation")]
    public virtual ICollection<Pracownicy> Pracownicies { get; set; } = new List<Pracownicy>();
}
