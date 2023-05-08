using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounter.Models
{
        public class Ausleihe
        {
            public int AusleihID { get; set; }
            public int KundenID { get; set; }
            public int ArtikelID { get; set; }
            public DateTime AusleihDatum { get; set; }
            public DateTime AbgabeFrist { get; set; }
            public int ArtikelAnzahl { get; set; }
        }

}
