

using System.Threading.Tasks;
using ProEventos.Domain;

namespace PRoEventos.PErsistence.Contratos
{
    public interface IPalestrantePersist
    {
        
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
        Task<Palestrante[]> GetAllPalestranteAsync(bool includeEventos);
        Task<Palestrante> GetPalestrantesByIdAsync(int palestranteId, bool includeEventos);

    }
}