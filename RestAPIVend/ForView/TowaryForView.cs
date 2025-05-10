using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestAPIVend.ForView
{
    public class TowaryForView
    {
        [Key]
        public int Idtowaru { get; set; }

        public string Nazwa { get; set; } = null!;

        public string JednostkaMiary { get; set; } = null!;

        public string Producent { get; set; } = null!;

        public string? KodKreskowy { get; set; }

        public string? Wymiary { get; set; }

        public string? Opis { get; set; }
    }
}
