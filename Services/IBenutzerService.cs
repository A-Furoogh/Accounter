using Accounter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounter.Services
{
    public interface IBenutzerService
    {
        Task<List<Benutzer>> GetBenutzerList();
        Task<int> AddBenutzer(Benutzer benutzer);
        Task<int> UpdateBenutzer(Benutzer benutzer);
        Task<int> DeleteBenutzer(Benutzer benutzer);
    }
}
