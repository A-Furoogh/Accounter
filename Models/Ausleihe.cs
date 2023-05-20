using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Accounter.Models
{
        [Table("Ausleihe")]
        public class Ausleihe
        {
            [PrimaryKey]
            public int ArtID { get; set; }
            public int KundID { get; set; }
            public DateTime AusleiheDatum { get; set; }
            public DateTime AbgabeFrist { get; set; }
            public int ArtAnzahl { get; set; }
        }

}
