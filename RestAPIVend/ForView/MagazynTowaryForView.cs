using RestAPIVend.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestAPIVend.ForView
{
    public class MagazynTowaryForView
    {
        [Key]
        public int Idmagazynu { get; set; }

        public string? MagazynData { get; set; }

        [Key]
        public int Idtowaru { get; set; }
        public string? TowarData { get; set; }

        public int Stan { get; set; }

        public string? Opis { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Data { get; set; }

        public bool? IsActive { get; set; }
    }
}
