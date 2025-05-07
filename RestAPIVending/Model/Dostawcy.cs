using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPIVending.Model;

[Table("Dostawcy")]
public partial class Dostawcy
{
    [Key]
    [Column("IDDostawcy")]
    public int Iddostawcy { get; set; }

    [StringLength(50)]
    public string Nazwa { get; set; } = null!;

    [StringLength(50)]
    public string? Ulica { get; set; }

    [StringLength(50)]
    public string? Miasto { get; set; }

    [StringLength(10)]
    public string? KodPocztowy { get; set; }

    [StringLength(50)]
    public string? Kraj { get; set; }

    [StringLength(50)]
    public string? Opis { get; set; }

    public bool? IsActive { get; set; }

    [InverseProperty("IddostawcyNavigation")]
    public virtual ICollection<ZamowieniaZewnetrzne> ZamowieniaZewnetrznes { get; set; } = new List<ZamowieniaZewnetrzne>();
}
