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
        private SQLiteAsyncConnection _dbConnection;
        string _dbPath;
        public BenutzerService() 
        {

        }

        private async Task SetupDatabase()
        {

            if(_dbConnection is not null)
                return;

            _dbConnection = new SQLiteAsyncConnection(_dbPath);
            await _dbConnection.CreateTableAsync<Benutzer>();
        }
        public Task<int> DeleteBenutzer(Benutzer benutzer)
        {
            return _dbConnection.DeleteAsync(benutzer);
        }

        public async Task<List<Benutzer>> GetBenutzerList()
        {
            try 
            {
                await SetupDatabase();
                return await _dbConnection.Table<Benutzer>().ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return new List<Benutzer>();
        }

        public Task<int> UpdateBenutzer(Benutzer benutzer)
        {
            return _dbConnection.UpdateAsync(benutzer);
        }

        public async Task<int> AddBenutzer(Benutzer benutzer)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(benutzer));
            try
            {
                await SetupDatabase();
                return await _dbConnection.InsertAsync(benutzer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
