using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPIVending.Model;

[PrimaryKey("Idtowaru", "MaszynaId")]
[Table("MaszynaTowary")]
public partial class MaszynaTowary
{
    [Key]
    [Column("IDTowaru")]
    public int Idtowaru { get; set; }

    public int Stan { get; set; }

    [StringLength(50)]
    public string? Opis { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? Data { get; set; }

    public bool? IsActive { get; set; }

    [Key]
    [Column("maszyna_id")]
    public int MaszynaId { get; set; }

    [ForeignKey("Idtowaru")]
    [InverseProperty("MaszynaTowaries")]
    public virtual Towary IdtowaruNavigation { get; set; } = null!;

    [ForeignKey("MaszynaId")]
    [InverseProperty("MaszynaTowaries")]
    public virtual Maszyny Maszyna { get; set; } = null!;
}
