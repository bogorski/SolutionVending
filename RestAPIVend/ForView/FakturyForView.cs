using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestAPIVend.ForView
{
    public class FakturyForView
    {
        [Key]
        public int Idfaktury { get; set; }

        public string Nip { get; set; } = null!;

        public string NazwaSprzedawcy { get; set; } = null!;

        public string Ulica { get; set; } = null!;

        public string Miasto { get; set; } = null!;

        public string KodPocztowy { get; set; } = null!;

        public string Kraj { get; set; } = null!;

        public decimal WartoscNetto { get; set; }

        public decimal WartoscBrutto { get; set; }

        public int Vat { get; set; }

        public DateTime DataWystawienia { get; set; }

        public string NumerFaktury { get; set; } = null!;

    }
}
