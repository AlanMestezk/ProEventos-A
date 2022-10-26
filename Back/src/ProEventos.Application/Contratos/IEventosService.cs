using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Contratos
{
    public interface IEventoService
    {

        Task<Evento> AddEventos(Evento model );
        Task<Evento> UpdateEvento(int eventoId, Evento model );
        Task<bool> DeleteEvento(int eventoId );


        Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false);
        Task<Evento[]> GetAllEventoByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento> GetEventosByIdAsync(int eventoId, bool includePalestrantes = false);

    }
}