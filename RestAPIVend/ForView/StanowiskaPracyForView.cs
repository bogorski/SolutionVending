using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestAPIVend.ForView
{
    public class StanowiskaPracyForView
    {
        [Key]
        public int IdstanowiskaPracy { get; set; }

        public string NazwaStanowiska { get; set; } = null!;

        public string Dzial { get; set; } = null!;

        public int WymaganeDoswiadczenie { get; set; }

        public string Status { get; set; } = null!;

        public string? Opis { get; set; }

        public DateOnly? DataUtworzenia { get; set; }
    }
}
