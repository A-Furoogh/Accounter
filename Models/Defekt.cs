using SQLite;

namespace Accounter.Models
{
    [Table("Defekt")]
    public class Defekt
    {
        [PrimaryKey, AutoIncrement]
        public int DefektID { get; set; }
        public int ArtID { get; set; }
        public string ArtName { get; set; }
        public int Anzahl { get; set; }
        public string Anmerkung { get; set; }
        public string Image { get; set; }
    }
}
