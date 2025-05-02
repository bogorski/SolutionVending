using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestAPIVend.ForView
{
    public class DostawcyForView
    {
        [Key]
        public int Iddostawcy { get; set; }

        public string Nazwa { get; set; } = null!;

        //public string? Ulica { get; set; }

        public string? Miasto { get; set; }

        public string? KodPocztowy { get; set; }

        public string? Kraj { get; set; }

        public string? Opis { get; set; }
    }
}
