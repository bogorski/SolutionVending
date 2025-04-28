using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPIVend.Model;

[Table("Wizyty")]
public partial class Wizyty
{
    [Key]
    [Column("IDWizyty")]
    public int Idwizyty { get; set; }

    [Column("IDPracownika")]
    public int Idpracownika { get; set; }

    [StringLength(10)]
    public string NumerMaszyny { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime Data { get; set; }

    [StringLength(50)]
    public string TypWizyty { get; set; } = null!;

    [StringLength(50)]
    public string? Opis { get; set; }

    public bool? IsActive { get; set; }

    [ForeignKey("Idpracownika")]
    [InverseProperty("Wizyties")]
    public virtual Pracownicy IdpracownikaNavigation { get; set; } = null!;

    [ForeignKey("NumerMaszyny")]
    [InverseProperty("Wizyties")]
    public virtual Maszyny NumerMaszynyNavigation { get; set; } = null!;
}
