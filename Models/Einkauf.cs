using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounter.Models
{
        public class Einkauf
        {
            public int BestellID { get; set; }
            public DateTime BestellDatum { get; set; }
            public int BestellAnzahl { get; set; }
            public decimal EinkaufsPreis { get; set; }
        }
    }

