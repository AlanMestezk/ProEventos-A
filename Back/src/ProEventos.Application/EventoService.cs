using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using PRoEventos.PErsistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {

        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;
        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist )
        {
            _geralPersist = geralPersist;
            _eventoPersist = eventoPersist;
        }

        public  async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _geralPersist.Add<Evento>(model);
                if(await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventosByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception($"Vixi, deu erro: {ex.Message}");
            }
        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
           try
           {
             var evento = await _eventoPersist.GetEventosByIdAsync(eventoId, false);
             if(evento == null) return null;

             model.Id = evento.Id;

             _geralPersist.Update(model);
             if(await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventosByIdAsync(model.Id, false);
                }
                return null;
           }
           catch (Exception ex)
            {
                
                throw new Exception($"Vixi, deu erro: {ex.Message}");
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
           {
             var evento = await _eventoPersist.GetEventosByIdAsync(eventoId, false);
             if(evento == null) throw new Exception("Evento para delete não foi encontrado.");

             _geralPersist.Delete<Evento>(evento);
             return await _geralPersist.SaveChangesAsync();
           }
           catch (Exception ex)
            {
                
                throw new Exception($"Vixi, deu erro: {ex.Message}");
            }
        }

        public Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false)
        {
            throw new NotImplementedException();
        }

        public Task<Evento[]> GetAllEventoByTemaAsync(string tema, bool includePalestrantes = false)
        {
            throw new NotImplementedException();
        }

        public Task<Evento> GetEventosByIdAsync(int EventoId, bool includePalestrantes = false)
        {
            throw new NotImplementedException();
        }

    }
}