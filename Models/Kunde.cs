using SQLite;

namespace Accounter.Models
{
        [Table("Kunde")]
        public class Kunde
        {
            [PrimaryKey, AutoIncrement]
            public int KundID { get; set; }
            public string KundName { get; set; }
            public int Matrik { get; set; }
            public string Email { get; set; }
            public string Vermerk { get; set; }
        }
}

