using Accounter.Models;

namespace Accounter.Services
{
    public interface IDefektService
    {
        Task<List<Defekt>> GetDefektList();
        Task AddDefekt(Defekt defekt);
        Task UpdateDefekt(Defekt defekt);
        Task DeleteDefekt(Defekt defekt);
        Task DeleteAllDefekte();
    }
}
