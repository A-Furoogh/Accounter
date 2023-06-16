using SQLite;


namespace Accounter.Models
{
        [Table("Ausleihe")]
        public class Ausleihe
        {
            [PrimaryKey, AutoIncrement]
            public int AusleiheID { get; set; }
            public int ArtID { get; set; }
            public int KundID { get; set; }
            public DateTime AusleiheDatum { get; set; }
            public DateTime AbgabeFrist { get; set; }
            public int ArtAnzahl { get; set; }
            public string Image { get; set; }
            public string ArtName { get; set; }
        }

}
