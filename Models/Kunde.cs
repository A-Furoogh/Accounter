using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounter.Models
{
        public class Kunde
        {
            public int KundID { get; set; }
            public string KundName { get; set; }
            public int Matrik { get; set; }
            public string Email { get; set; }
            public string Vermerk { get; set; }
        }
}

