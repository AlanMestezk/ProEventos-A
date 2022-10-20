using System;
using System.Collections.Generic;

namespace ProEventos.Domain
{
    public class Evento
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime? DataEvento{get; set;}
        public string Tema {get; set;}
        public int QtdPessoas { get; set; }
        public int Lote { get; set; }
        public string ImgURL {get; set;}
        public string Telefone { get; set; }
        public string Email { get; set; }
        public IEnumerable<LOte> Lotes { get; set; }
        public IEnumerable<RedeSocial> RedesSociais { get; set; }
        public IEnumerable<PalestranteEvento> PalestranteEventos { get; set; }

    }
}