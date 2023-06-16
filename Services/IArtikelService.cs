using Accounter.Models;

namespace Accounter.Services
{
    public interface IArtikelService
    {
        Task<List<Artikel>> GetArtikelList();
        Task AddArtikel(Artikel artikel);
        Task UpdateArtikel(Artikel artikel);
        Task DeleteArtikel(Artikel artikel);
        Task DeleteAllArtikels();
    }
}
