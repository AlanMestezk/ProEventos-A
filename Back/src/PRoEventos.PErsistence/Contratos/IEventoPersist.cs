

using System.Threading.Tasks;
using ProEventos.Domain;

namespace PRoEventos.PErsistence.Contratos
{
    public interface IEventoPersist
    {
    
        Task<Evento[]> GetAllEventoByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false);
        Task<Evento> GetEventosByIdAsync(int eventoId, bool includePalestrantes = false);

    }
}