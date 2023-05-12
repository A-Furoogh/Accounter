﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounter.Models
{
   
        public class Artikel
        {
            public int ArtID { get; set; }
            public string ArtName { get; set; }
            public bool Ausleihbar { get; set; }
            public decimal PreisProTag { get; set; }
            public decimal PreisGesamt { get; set; }
            public int Anzahllager { get; set; }
            public DateTime AblaufsDatum { get; set; }
            public DateTime NaechstePruefDatum { get; set; }
            public string LagerPlatz { get; set; }
            public int BestandLimit { get; set; }
            public int Barcode { get; set; }
        }
    }

