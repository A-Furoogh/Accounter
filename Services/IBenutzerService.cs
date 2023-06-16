using Accounter.ViewModels;

namespace Accounter.Services
{
    public interface IBenutzerService
    {
        Task<List<Benutzer>> GetBenutzerList();
        Task AddBenutzer(Benutzer benutzer);
        Task UpdateBenutzer(Benutzer benutzer);
        Task DeleteBenutzer(Benutzer benutzer);
    }
}
