using Accounter.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounter.ViewModels;

namespace Accounter.Services
{
    public class ArtikelService : IArtikelService
    {
        static SQLiteAsyncConnection dbConnection;
        // Initial-Artikel-Daten
        //Artikel a1 = new Artikel() { ArtName = "Kaffee", PreisProTag = 2.6M, Image = "what.png" };
        //Artikel a2 = new Artikel() { ArtName = "Tee", PreisProTag = 2.00M, Image = "what.png" };
        //Artikel a3 = new Artikel() { ArtName = "Wasser", PreisProTag = 1.50M, Image = "what.png" };
        //Artikel a4 = new Artikel() { ArtName = "Cola", PreisProTag = 2.50M, Image = "what.png" };
        //Artikel a5 = new Artikel() { ArtName = "Bier", PreisProTag = 3.00M, Image = "what.png" };
        public ArtikelService()
        {
            //_ = AddArtikel(a1);
            //_ = AddArtikel(a2);
            //_ = AddArtikel(a3);
            //_ = AddArtikel(a4);
            //_ = AddArtikel(a5);

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

            await dbConnection.CreateTableAsync<Artikel>();
        }

        public async Task<List<Artikel>> GetArtikelList()
        {
            await Init();
            return await dbConnection.Table<Artikel>().ToListAsync();
        }

        public async Task UpdateArtikel(Artikel artikel)
        {
            await Init();

            await dbConnection.UpdateAsync(artikel);
        }
        public async Task AddArtikel(Artikel artikel)
        {
            await Init();

            await dbConnection.InsertAsync(artikel);
        }

        public async Task DeleteArtikel(Artikel artikel)
        {
            await Init();

            await dbConnection.DeleteAsync(artikel);
        }
    }
}
