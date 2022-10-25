using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace PRoEventos.PErsistence.Contexto
{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions <ProEventosContext> options)
         : base(options){}
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<LOte> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestranteEventos { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new {PE.EventoId, PE.PalestranteId});
        }
    }
}