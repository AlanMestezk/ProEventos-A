using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pro_Eventos.Api.Data;
using Pro_Eventos.Api.Models;

namespace Pro_Eventos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {

        private readonly DataContext _context;
       
        public EventosController(DataContext context){
                this._context = context;
        }
            

        [HttpGet]
        public IEnumerable<Evento> Get(){
            return _context.Eventos;
        }

        [HttpGet("{id}")]
        public Evento GetById(int id){
            return _context.Eventos.FirstOrDefault(evento => evento.EventoId == id);
        }
       
        [HttpPost("{id}")]
        public string Post(int id){
            return $"Criando: usuário {id}";
        }

        [HttpPut("{id}")]
        public string Put(int id){
            return $"Atualizando os dados: usuário {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id){
            return $"Deletando: usuário {id}";
        }
    }
}
