using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestAPIVend.ForView
{
    public class MaszynyForView
    {
        public string NumerMaszyny { get; set; } = null!;

        public int IdtypMaszyny { get; set; }
        public string? TypMaszynyData { get; set; }

        public string NumerSeryjny { get; set; } = null!;

        [Column(TypeName = "datetime")]
        public DateTime RokProdukcji { get; set; }

        public string? Opis { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DataMontazu { get; set; }

        public bool? IsActive { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        [Key]
        public int Id { get; set; }
    }
}
