using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounter.Models;
using SQLite;

namespace Accounter.Services
{
    public class AusleiheService : IAusleiheService
    {

        static SQLiteAsyncConnection dbConnection;

        public AusleiheService()
        {
            _ = Init();
        }

        private async Task Init()
        {
            if (dbConnection != null)
            {
                return;
            }
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Accounter.db");
            dbConnection = new SQLiteAsyncConnection(dbPath);
            await dbConnection.CreateTableAsync<Ausleihe>();
        }
        public async Task AddAusleihe(Ausleihe artikel)
        {
            await dbConnection.InsertAsync(artikel);
        }

        public async Task DeleteAusleihe(Ausleihe artikel)
        {
            await dbConnection.DeleteAsync(artikel);
        }

        public async Task<List<Ausleihe>> GetAusleiheList()
        {
            return await dbConnection.Table<Ausleihe>().ToListAsync();
        }

        public async Task UpdateAusleihe(Ausleihe artikel)
        {
            await dbConnection.UpdateAsync(artikel);
        }
    }
}
