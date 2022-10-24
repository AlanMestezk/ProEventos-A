

using System.Threading.Tasks;
using ProEventos.Domain;

namespace PRoEventos.PErsistence
{
    public interface IProEventosPersistence
    {
        
        //GERAL

        void Add<T>(T entity) where T : class;
        
        void Update<T>(T entity) where T : class;
        
        void Delete<T>(T entity) where T : class;
        
        void DeleteRange<T>(T[] entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Eventos

        Task<Evento[]> GetAllEventoByTemaAsync(string tema, bool includePalestrantes);
        Task<Evento[]> GetAllEventoAsync(bool includePalestrantes);
        Task<Evento> GetEventosByIdAsync(int EventoId, bool includePalestrantes);

        //Palestrantes

        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string Nome, bool includeEventos);
        Task<Palestrante[]> GetAllPalestranteAsync(bool includeEventos);
        Task<Palestrante[]> GetPalestrantesByIdAsync(int PalestranteId, bool includeEventos);

    }
}