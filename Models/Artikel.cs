using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounter.Models
{
   
        public class Artikel
        {
            public int ArtikelID { get; set; }
            public string ArtikelName { get; set; }
            public int Barcode { get; set; }
            public decimal VerkaufsPreis { get; set; }
            public bool Ausleihbar { get; set; }
            public decimal PreisProTag { get; set; }
            public int AnzahlLager { get; set; }
        }
    }

