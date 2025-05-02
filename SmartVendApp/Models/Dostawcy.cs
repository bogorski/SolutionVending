using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVendApp.Models
{
    public class Dostawcy
    {
        public int Iddostawcy { get; set; }
        public string? Nazwa { get; set; }

        public string? Ulica { get; set; }

        public string? Miasto { get; set; }

        public string? KodPocztowy { get; set; }

        public string? Kraj { get; set; }

        public string? Opis { get; set; }

        public bool? IsActive { get; set; }
    }
}
