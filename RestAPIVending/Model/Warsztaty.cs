using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPIVending.Model;

[Table("Warsztaty")]
public partial class Warsztaty
{
    [Key]
    [Column("IDWarsztatu")]
    public int Idwarsztatu { get; set; }

    [StringLength(50)]
    public string Nazwa { get; set; } = null!;

    [StringLength(50)]
    public string Ulica { get; set; } = null!;

    [StringLength(50)]
    public string Miasto { get; set; } = null!;

    [StringLength(6)]
    public string KodPocztowy { get; set; } = null!;

    [StringLength(50)]
    public string Kraj { get; set; } = null!;

    [StringLength(50)]
    public string? Opis { get; set; }

    public bool? IsActive { get; set; }

    [InverseProperty("IdwarsztatuNavigation")]
    public virtual ICollection<Pojazdy> Pojazdies { get; set; } = new List<Pojazdy>();
}
