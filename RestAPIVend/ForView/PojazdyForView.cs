using RestAPIVend.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestAPIVend.ForView
{
    public class PojazdyForView
    {
        [Key]
        public int Idpojazdu { get; set; }

        public string Marka { get; set; } = null!;

        public string NumerRejestracyjny { get; set; } = null!;

        [Column(TypeName = "datetime")]
        public DateTime DataPrzegladu { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataUbezpieczenia { get; set; }
        public int? Idwarsztatu { get; set; }

        public string? WarsztatData { get; set; }

        public string? Opis { get; set; }

        public string? Usterki { get; set; }

        public bool? IsActive { get; set; }

    }
}
