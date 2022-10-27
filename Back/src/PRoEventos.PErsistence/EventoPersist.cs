using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using PRoEventos.PErsistence.Contexto;
using PRoEventos.PErsistence.Contratos;

namespace PRoEventos.PErsistence
{
    public class EventoPersist : IEventoPersist
    {
        private readonly ProEventosContext _context;
        public ProEventosContext Context { get; }
        public EventoPersist(ProEventosContext context)
        {
            _context = context;
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                                               .Include(e => e.Lotes)
                                               .Include(e => e.RedesSociais);

            if(includePalestrantes){
                query = query
                        .Include(e => e.PalestranteEventos)
                        .ThenInclude(pe => pe.Palestrante);        
            }

            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();

        }

        public async Task<Evento[]> GetAllEventoByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                                               .Include(e => e.Lotes)
                                               .Include(e => e.RedesSociais);

            if(includePalestrantes){
                query = query
                        .Include(e => e.PalestranteEventos)
                        .ThenInclude(pe => pe.Palestrante);        
            }

            query = query.AsNoTracking().OrderBy(e => e.Id)
                         .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventosByIdAsync(int eventoId, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
                                               .Include(e => e.Lotes)
                                               .Include(e => e.RedesSociais);

            if(includePalestrantes){
                query = query
                        .Include(e => e.PalestranteEventos)
                        .ThenInclude(pe => pe.Palestrante);        
            }

            query = query.AsNoTracking().OrderBy(e => e.Id)
                         .Where(e => e.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }

        
    }
}