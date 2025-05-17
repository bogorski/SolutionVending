using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestAPIVend.ForView
{
    public class PracownicyForView
    {
        [Key]
        public int Idpracownika { get; set; }

        public string Imie { get; set; } = null!;

        public string Nazwisko { get; set; } = null!;

        public int IdstanowiskaPracy { get; set; }

        public string? StanowiskoPracyData { get; set; }
        public decimal Pensja { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataZatrudnienia { get; set; }

        public int? Idpojazdu { get; set; }
        public string? PojazdData { get; set; }

        public int? Idtrasy { get; set; }
        public string? TrasaData { get; set; }

        public string? Opis { get; set; }

        public bool? IsActive { get; set; }
    }
}
