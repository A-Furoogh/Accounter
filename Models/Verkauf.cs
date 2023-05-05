using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchhalter_ME.Models
{
        public class Verkauf
        {
            public int ArtikelID { get; set; }
            public int Anzahl { get; set; }
            public decimal VerkaufsPreis { get; set; }
            public DateTime VerkaufsDatum { get; set; }
            public int KundenID { get; set; }
        }

}
