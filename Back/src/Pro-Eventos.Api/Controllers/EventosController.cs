﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using PRoEventos.PErsistence.Contexto;

namespace Pro_Eventos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {

       
        private readonly IEventoService  _eventoService;

        public EventosController(IEventoService eventoService){
            _eventoService = eventoService;
                
        }
            

        [HttpGet]
        public async Task<IActionResult> Get(){
            try
            {
                var eventos = await _eventoService.GetAllEventoAsync(true);
                if(eventos == null) return NotFound("Nenhum evento encontrado");

                return Ok(eventos);
            }
            catch (Exception ex )
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao tentar recuperar eventos. Erro: {ex.Message}" );
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id){
            try
            {
                var evento = await _eventoService.GetEventosByIdAsync(id, true);
                if(evento == null) return NotFound($"Nenhum evento por id {id} encontrado");

                return Ok(evento);
            }
            catch (Exception ex )
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao tentar recuperar eventos. Erro: {ex.Message}" );
            }
        }
       
        [HttpGet("{tema}/tema")]
        public async Task<IActionResult> GetByTema(string tema){
            try
            {
                var evento = await _eventoService.GetAllEventoByTemaAsync(tema, true);
                if(evento == null) return NotFound($"Evento por tema {tema} não encontrados.");

                return Ok(evento);
            }
            catch (Exception ex )
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao tentar recuperar eventos. Erro: {ex.Message}" );
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(Evento model){
            try
            {
                var evento = await _eventoService.AddEventos(model);
                if(evento == null) return BadRequest($"Erro ao tentar adicionar o evento {model}");

                return Ok(evento);
            }
            catch (Exception ex )
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao tentar recuperar eventos. Erro: {ex.Message}" );
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
            try
            {
                var evento = await _eventoService.UpdateEvento(id, model);
                if(evento == null) return BadRequest($"Erro ao tentar adicionar evento {id}");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao tentar adicionar eventos. Erro: {ex.Message}" );
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _eventoService.DeleteEvento(id) ?
                    Ok($"Deletado o {id}") :
                    BadRequest($"Evento {id} não deletado");
                
            }
            catch (Exception ex)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro ao tentar deletar eventos. Erro: {ex.Message}" );
            }
        }
    }
}
