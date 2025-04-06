using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestApiVending.Model;

[Table("TypyMaszyn")]
public partial class TypyMaszyn
{
    [Key]
    [Column("IDTypMaszyny")]
    public int IdtypMaszyny { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Typ { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Producent { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Model { get; set; } = null!;

    [StringLength(50)]
    public string? Opis { get; set; }

    [InverseProperty("IdtypMaszynyNavigation")]
    public virtual ICollection<Maszyny> Maszynies { get; set; } = new List<Maszyny>();
}
