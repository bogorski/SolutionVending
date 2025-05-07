using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPIVending.Model;

[Table("Maszyny")]
[Index("NumerMaszyny", Name = "UQ_Maszyny_numerMaszyny", IsUnique = true)]
public partial class Maszyny
{
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

    [Key]
    [Column("id")]
    public int Id { get; set; }

    [ForeignKey("IdtypMaszyny")]
    [InverseProperty("Maszynies")]
    public virtual TypyMaszyn IdtypMaszynyNavigation { get; set; } = null!;

    [InverseProperty("Maszyna")]
    public virtual ICollection<LokalizacjaMaszyny> LokalizacjaMaszynies { get; set; } = new List<LokalizacjaMaszyny>();

    [InverseProperty("Maszyna")]
    public virtual ICollection<MaszynaTowary> MaszynaTowaries { get; set; } = new List<MaszynaTowary>();

    [InverseProperty("Maszyna")]
    public virtual ICollection<MaszynaTrasa> MaszynaTrasas { get; set; } = new List<MaszynaTrasa>();

    [InverseProperty("Maszyna")]
    public virtual ICollection<Transakcje> Transakcjes { get; set; } = new List<Transakcje>();

    [InverseProperty("Maszyna")]
    public virtual ICollection<Wizyty> Wizyties { get; set; } = new List<Wizyty>();
}
