using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPIVend.Model;

[Table("Maszyny")]
public partial class Maszyny
{
    [Key]
    [StringLength(10)]
    public string NumerMaszyny { get; set; } = null!;

    [Column("IDTypMaszyny")]
    public int IdtypMaszyny { get; set; }

    [StringLength(50)]
    public string NumerSeryjny { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime RokProdukcji { get; set; }

    [StringLength(50)]
    public string? Opis { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataMontazu { get; set; }

    public bool? IsActive { get; set; }

    [ForeignKey("IdtypMaszyny")]
    [InverseProperty("Maszynies")]
    public virtual TypyMaszyn IdtypMaszynyNavigation { get; set; } = null!;

    [InverseProperty("NumerMaszynyNavigation")]
    public virtual LokalizacjaMaszyny? LokalizacjaMaszyny { get; set; }

    [InverseProperty("NumerMaszynyNavigation")]
    public virtual ICollection<MaszynaTowary> MaszynaTowaries { get; set; } = new List<MaszynaTowary>();

    [InverseProperty("NumerMaszynyNavigation")]
    public virtual ICollection<MaszynaTrasa> MaszynaTrasas { get; set; } = new List<MaszynaTrasa>();

    [InverseProperty("NumerMaszynyNavigation")]
    public virtual ICollection<Transakcje> Transakcjes { get; set; } = new List<Transakcje>();

    [InverseProperty("NumerMaszynyNavigation")]
    public virtual ICollection<Wizyty> Wizyties { get; set; } = new List<Wizyty>();
}
