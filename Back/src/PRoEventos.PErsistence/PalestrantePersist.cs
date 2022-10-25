using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using PRoEventos.PErsistence.Contexto;
using PRoEventos.PErsistence.Contratos;

namespace PRoEventos.PErsistence
{
    public class PalestrantePersist : IPalestrantePersist
    {
        private readonly ProEventosContext _context;
        public ProEventosContext Context { get; }
        public PalestrantePersist(ProEventosContext context)
        {
            _context = context;
        }

        public async Task<Palestrante[]> GetAllPalestranteAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                                    .Include(e => e.RedeSociais);

            if(includeEventos){
                query = query
                        .Include(p => p.PalestranteEventos)
                        .ThenInclude(pe => pe.Evento);        
            }

            query = query.OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                                    .Include(p => p.RedeSociais);

            if(includeEventos){
                query = query
                        .Include(p => p.PalestranteEventos)
                        .ThenInclude(pe => pe.Evento);        
            }

            query = query.OrderBy(p => p.Id)
                                    .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Palestrante> GetPalestrantesByIdAsync(int palestranteId, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                                    .Include(p => p.RedeSociais);

            if(includeEventos){
                query = query
                        .Include(p => p.PalestranteEventos)
                        .ThenInclude(pe => pe.Evento);        
            }

            query = query.OrderBy(p => p.Id)
                                    .Where(p => p.Id== palestranteId);

            return await query.FirstOrDefaultAsync();
        }

        
    }
}