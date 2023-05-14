using Accounter.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounter.Services
{
    public class BenutzerService : IBenutzerService
    {
        static SQLiteAsyncConnection dbConnection;

        //Initial-Benutzer-Daten
        Benutzer bb = new Benutzer() { Benutzername = "Admin", Passwort = "12345" };
        Benutzer b1 = new Benutzer() { Benutzername = "User", Passwort = "12345" };
        public BenutzerService() 
        {
            _ = AddBenutzer(bb);
            _ = AddBenutzer(b1);
        }

        private async Task Init()
        {
            if (dbConnection != null)
                return;

            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Accounter.db");

            dbConnection = new SQLiteAsyncConnection(dbPath);

            await dbConnection.CreateTableAsync<Benutzer>();
        }
        public async Task DeleteBenutzer(Benutzer benutzer)
        {
            await Init();

            await dbConnection.DeleteAsync(benutzer);
        }

        public async Task<List<Benutzer>> GetBenutzerList()
        {
            await Init();

            return await dbConnection.Table<Benutzer>().ToListAsync();
            
        }

        public async Task UpdateBenutzer(Benutzer benutzer)
        {
            await Init();

            await dbConnection.UpdateAsync(benutzer);
        }

        public async Task AddBenutzer(Benutzer benutzer)
        {
            await  Init();
            
            await dbConnection.InsertAsync(benutzer);
        }
    }
}
