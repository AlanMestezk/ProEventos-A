

using System.Collections.Generic;

namespace ProEventos.Domain
{
    public class Palestrante
    {

        public int Id { get; set; } 
        public string Nome { get; set; }
        public string MiniCurriculo { get; set; }
        public string ImgUrl { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public IEnumerable<RedeSocial> RedeSociais{ get; set; }
        public IEnumerable<PalestranteEvento> PalestranteEventos { get; set; }

    }
}