using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPIVend.Model;

[Table("Transakcje")]
public partial class Transakcje
{
    [Key]
    [Column("IDTransakcji")]
    public int Idtransakcji { get; set; }

    [StringLength(10)]
    public string NumerMaszyny { get; set; } = null!;

    [Column("IDTowaru")]
    public int Idtowaru { get; set; }

    public int Ilosc { get; set; }

    [StringLength(10)]
    public string TypPlatnosci { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime Data { get; set; }

    [StringLength(50)]
    public string? Opis { get; set; }

    public bool? IsActive { get; set; }

    [ForeignKey("Idtowaru")]
    [InverseProperty("Transakcjes")]
    public virtual Towary IdtowaruNavigation { get; set; } = null!;

    [ForeignKey("NumerMaszyny")]
    [InverseProperty("Transakcjes")]
    public virtual Maszyny NumerMaszynyNavigation { get; set; } = null!;
}
