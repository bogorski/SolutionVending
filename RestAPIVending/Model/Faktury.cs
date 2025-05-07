using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPIVending.Model;

[Table("Faktury")]
public partial class Faktury
{
    [Key]
    [Column("IDFaktury")]
    public int Idfaktury { get; set; }

    [Column("NIP")]
    [StringLength(10)]
    public string Nip { get; set; } = null!;

    [StringLength(50)]
    public string NazwaSprzedawcy { get; set; } = null!;

    [StringLength(50)]
    public string Ulica { get; set; } = null!;

    [StringLength(50)]
    public string Miasto { get; set; } = null!;

    [StringLength(10)]
    public string KodPocztowy { get; set; } = null!;

    [StringLength(50)]
    public string Kraj { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal WartoscNetto { get; set; }

    [Column(TypeName = "money")]
    public decimal WartoscBrutto { get; set; }

    [Column("VAT")]
    public int Vat { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DataWystawienia { get; set; }

    [StringLength(50)]
    public string NumerFaktury { get; set; } = null!;

    public bool? IsActive { get; set; }

    [InverseProperty("IdfakturyNavigation")]
    public virtual ZamowieniaZewnetrzne? ZamowieniaZewnetrzne { get; set; }
}
