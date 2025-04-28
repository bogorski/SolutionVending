using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPIVend.Model;

[PrimaryKey("Idpracownika", "Idtowaru")]
[Table("PracownikTowary")]
public partial class PracownikTowary
{
    [Key]
    [Column("IDPracownika")]
    public int Idpracownika { get; set; }

    [Key]
    [Column("IDTowaru")]
    public int Idtowaru { get; set; }

    public int Stan { get; set; }

    [StringLength(50)]
    public string? Opis { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Data { get; set; }

    public bool? IsActive { get; set; }

    [ForeignKey("Idpracownika")]
    [InverseProperty("PracownikTowaries")]
    public virtual Pracownicy IdpracownikaNavigation { get; set; } = null!;

    [ForeignKey("Idtowaru")]
    [InverseProperty("PracownikTowaries")]
    public virtual Towary IdtowaruNavigation { get; set; } = null!;
}
