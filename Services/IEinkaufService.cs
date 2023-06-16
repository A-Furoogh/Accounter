using Accounter.Models;

namespace Accounter.Services
{
    public interface IEinkaufService
    {
        Task<List<Einkauf>> GetEinkaufsList();
        Task AddEinkauf(Einkauf einkauf);
        Task UpdateEinkauf(Einkauf einkauf);
        Task DeleteEinkauf(Einkauf einkauf);
        Task DeleteAllEinkaeufe();
    }
}
