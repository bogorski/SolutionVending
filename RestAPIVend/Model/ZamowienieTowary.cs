using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestAPIVend.Model;

[PrimaryKey("Idzamowienia", "Idtowaru")]
[Table("ZamowienieTowary")]
public partial class ZamowienieTowary
{
    [Key]
    [Column("IDZamowienia")]
    public int Idzamowienia { get; set; }

    [Key]
    [Column("IDTowaru")]
    public int Idtowaru { get; set; }

    public bool? IsActive { get; set; }

    [ForeignKey("Idtowaru")]
    [InverseProperty("ZamowienieTowaries")]
    public virtual Towary IdtowaruNavigation { get; set; } = null!;

    [ForeignKey("Idzamowienia")]
    [InverseProperty("ZamowienieTowaries")]
    public virtual Zamowienia IdzamowieniaNavigation { get; set; } = null!;
}
