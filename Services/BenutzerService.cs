using Accounter.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounter.Services
{
    internal class BenutzerService : IBenutzerService
    {
        public SQLiteAsyncConnection _dbConnection;
        public BenutzerService() 
        {
            SetupDatabase();
        }

        private async void SetupDatabase()
        {
            if(_dbConnection == null) 
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Accounter.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<Benutzer>();
            }
            
        }

        public Task<int> DeleteBenutzer(Benutzer benutzer)
        {
            return _dbConnection.DeleteAsync(benutzer);
        }

        public Task<List<Benutzer>> GetBenutzerList()
        {
            var benutzerListe = _dbConnection.Table<Benutzer>().ToListAsync();
            return benutzerListe;
        }

        public Task<int> UpdateBenutzer(Benutzer benutzer)
        {
            return _dbConnection.UpdateAsync(benutzer);
        }

        public Task<int> AddBenutzer(Benutzer benutzer)
        {
            return _dbConnection.InsertAsync(benutzer);
        }
    }
}
