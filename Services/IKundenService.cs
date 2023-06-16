using Accounter.Models;

namespace Accounter.Services
{
    public interface IKundenService
    {
        Task<List<Kunde>> GetKundenList();
        Task AddKunde(Kunde kunde);
        Task UpdateKunde(Kunde kunde);
        Task DeleteKunde(Kunde kunde);
        Task DeleteAllKunden();
    }
}
