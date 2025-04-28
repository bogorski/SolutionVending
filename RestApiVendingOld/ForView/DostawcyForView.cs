using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RestApiVending.Model;
using RestApiVending.Helpers;

namespace RestApiVending.ForView
{
    public class DostawcyForView
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

        public static implicit operator Dostawcy(DostawcyForView cli)
            => new Dostawcy().CopyProperties(cli);
        public static implicit operator DostawcyForView(Dostawcy cli)
            => new DostawcyForView().CopyProperties(cli);
    }
}
