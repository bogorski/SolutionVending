//using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;

//namespace RestAPIVend.ForView
//{
//    public class MaszynyForView
//    {
//        public string NumerMaszyny { get; set; } = null!;

//        [Column("IDTypMaszyny")]
//        public int IdtypMaszyny { get; set; }

//        [StringLength(50)]
//        public string NumerSeryjny { get; set; } = null!;

//        [Column(TypeName = "datetime")]
//        public DateTime RokProdukcji { get; set; }

//        [StringLength(50)]
//        public string? Opis { get; set; }

//        [Column(TypeName = "datetime")]
//        public DateTime? DataMontazu { get; set; }

//        public bool? IsActive { get; set; }
//    }
//}
