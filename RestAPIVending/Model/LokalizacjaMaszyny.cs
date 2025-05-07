using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPIVending.Model;

[PrimaryKey("IdLokalizacji", "MaszynaId")]
[Table("LokalizacjaMaszyny")]
public partial class LokalizacjaMaszyny
{
    [Key]
    public int IdLokalizacji { get; set; }

    public bool? IsActive { get; set; }

    [Key]
    [Column("maszyna_id")]
    public int MaszynaId { get; set; }

    [ForeignKey("IdLokalizacji")]
    [InverseProperty("LokalizacjaMaszynies")]
    public virtual Lokalizacje IdLokalizacjiNavigation { get; set; } = null!;

    [ForeignKey("MaszynaId")]
    [InverseProperty("LokalizacjaMaszynies")]
    public virtual Maszyny Maszyna { get; set; } = null!;
}
