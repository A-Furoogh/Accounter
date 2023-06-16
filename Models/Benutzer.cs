using SQLite;

namespace Accounter.Models
{
    [Table("Benutzer")]
    public class Benutzer 
    {
        //Properties
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Benutzername { get; set; }
        public int Passwort { get; set; }

    }
}
