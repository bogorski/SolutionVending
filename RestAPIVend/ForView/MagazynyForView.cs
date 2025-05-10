using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestAPIVend.ForView
{
    public class MagazynyForView
    {
        [Key]
        public int Idmagazynu { get; set; }

        public string Nazwa { get; set; } = null!;

        public string Ulica { get; set; } = null!;

        public string Miasto { get; set; } = null!;

        public string KodPocztowy { get; set; } = null!;

        public string Kraj { get; set; } = null!;

        public string? Opis { get; set; }
    }
}
