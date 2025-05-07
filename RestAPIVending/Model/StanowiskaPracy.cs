using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPIVending.Model;

[Table("StanowiskaPracy")]
public partial class StanowiskaPracy
{
    [Key]
    [Column("IDStanowiskaPracy")]
    public int IdstanowiskaPracy { get; set; }

    [StringLength(50)]
    public string NazwaStanowiska { get; set; } = null!;

    [StringLength(50)]
    public string Dzial { get; set; } = null!;

    public int WymaganeDoswiadczenie { get; set; }

    [StringLength(50)]
    public string Status { get; set; } = null!;

    [StringLength(50)]
    public string? Opis { get; set; }

    public DateOnly? DataUtworzenia { get; set; }

    public bool? IsActive { get; set; }

    [InverseProperty("IdstanowiskaPracyNavigation")]
    public virtual ICollection<Pracownicy> Pracownicies { get; set; } = new List<Pracownicy>();
}
