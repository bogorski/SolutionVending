using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPIVending.Model;

[Table("Transakcje")]
public partial class Transakcje
{
    [Key]
    [Column("IDTransakcji")]
    public int Idtransakcji { get; set; }

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

    [Column("maszyna_id")]
    public int? MaszynaId { get; set; }

    [ForeignKey("Idtowaru")]
    [InverseProperty("Transakcjes")]
    public virtual Towary IdtowaruNavigation { get; set; } = null!;

    [ForeignKey("MaszynaId")]
    [InverseProperty("Transakcjes")]
    public virtual Maszyny? Maszyna { get; set; }
}
