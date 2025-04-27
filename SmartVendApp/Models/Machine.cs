using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVendApp.Models
{
    public class Machine
    {
        public string? NumerMaszyny { get; set; }
        public string? IdtypMaszyny { get; set; }
        public string? NumerSeryjny { get; set; }
        public DateTime RokProdukcji { get; set; }
        public string? Opis { get; set; }
        public DateTime DataMontazu { get; set; }
        
    }
}
