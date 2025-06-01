using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPIVend.Model;

[Table("Lokalizacje")]
public partial class Lokalizacje
{
    [Key]
    [Column("IDLokalizacji")]
    public int Idlokalizacji { get; set; }

    [StringLength(50)]
    public string NazwaKlienta { get; set; } = null!;

    [StringLength(50)]
    public string Ulica { get; set; } = null!;

    [StringLength(50)]
    public string Miasto { get; set; } = null!;

    [StringLength(10)]
    public string KodPocztowy { get; set; } = null!;

    [StringLength(50)]
    public string Kraj { get; set; } = null!;

    [StringLength(50)]
    public string? Opis { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    public bool? IsActive { get; set; }

    [InverseProperty("IdLokalizacjiNavigation")]
    public virtual ICollection<LokalizacjaMaszyny> LokalizacjaMaszynies { get; set; } = new List<LokalizacjaMaszyny>();
}
