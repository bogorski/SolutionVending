using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApiVending.Model;

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

    [InverseProperty("IdtrasyNavigation")]
    public virtual ICollection<Pracownicy> Pracownicies { get; set; } = new List<Pracownicy>();

    [ForeignKey("Idtrasy")]
    [InverseProperty("Idtrasies")]
    public virtual ICollection<Maszyny> NumerMaszynies { get; set; } = new List<Maszyny>();
}
