using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPIVend.Model;

[Table("Trasy")]
public partial class Trasy
{
    [Key]
    [Column("IDTrasy")]
    public int Idtrasy { get; set; }

    [StringLength(50)]
    public string Nazwa { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? DataUtworzenia { get; set; }

    [StringLength(50)]
    public string? Opis { get; set; }

    [StringLength(50)]
    public string? Ocena { get; set; }

    public bool? IsActive { get; set; }

    [InverseProperty("IdtrasyNavigation")]
    public virtual ICollection<MaszynaTrasa> MaszynaTrasas { get; set; } = new List<MaszynaTrasa>();

    [InverseProperty("IdtrasyNavigation")]
    public virtual ICollection<Pracownicy> Pracownicies { get; set; } = new List<Pracownicy>();
}
