using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace PRoEventos.PErsistence
{
    public class PeoEventosPersistence : IProEventosPersistence
    {
        private readonly ProEventosContext _context;
        public ProEventosContext Context { get; }
        public PeoEventosPersistence(ProEventosContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
           _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
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

            query = query.OrderBy(e => e.Id);

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

            query = query.OrderBy(e => e.Id)
                         .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventosByIdAsync(int EventoId, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
                                               .Include(e => e.Lotes)
                                               .Include(e => e.RedesSociais);

            if(includePalestrantes){
                query = query
                        .Include(e => e.PalestranteEventos)
                        .ThenInclude(pe => pe.Palestrante);        
            }

            query = query.OrderBy(e => e.Id)
                         .Where(e => e.Id == EventoId);

            return await query.FirstOrDefaultAsync();
        }
        public Task<Palestrante[]> GetAllPalestranteAsync(bool includeEventos)
        {
            throw new NotImplementedException();
        }

        public Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string Nome, bool includeEventos)
        {
            throw new NotImplementedException();
        }

        

        public Task<Palestrante[]> GetPalestrantesByIdAsync(int PalestranteId, bool includeEventos)
        {
            throw new NotImplementedException();
        }

        
    }
}