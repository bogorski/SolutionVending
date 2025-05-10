using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestAPIVend.ForView
{
    public class TrasyForView
    {
        [Key]
        public int Idtrasy { get; set; }

        public string Nazwa { get; set; } = null!;

        public DateTime? DataUtworzenia { get; set; }

        public string? Opis { get; set; }

        public string? Ocena { get; set; }

    }
}
