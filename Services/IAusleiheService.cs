using Accounter.Models;

namespace Accounter.Services
{
    public interface IAusleiheService
    {
        Task<List<Ausleihe>> GetAusleiheList();
        Task AddAusleihe(Ausleihe artikel);
        Task UpdateAusleihe(Ausleihe artikel);
        Task DeleteAusleihe(Ausleihe artikel);
        Task DeleteAllAusleihe();
    }
}
