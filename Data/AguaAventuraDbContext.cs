using Agua_e_Aventura.Models.Domain;
using Agua_e_Aventura.Models.Domain.Comentarios;
using Microsoft.EntityFrameworkCore;

namespace Agua_e_Aventura.Data
{
    public class AguaAventuraDbContext : DbContext
    {
        public AguaAventuraDbContext( DbContextOptions<AguaAventuraDbContext> dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<Praia> Praias { get; set; }

        public DbSet<Regiao> Regioes { get; set; }

        public DbSet<ComentarioPraia> ComentariosPraias { get; set; }

        public DbSet<RespostaComentarioPraia> RespostasComentariosPraias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed dados em regiões

            var regions = new List<Regiao>
            {
                new Regiao {Id=Guid.Parse("77ffa92c-a132-4e17-ab20-864e8fc76737"), Nome= "Manaus"},
                new Regiao {Id=Guid.Parse("99581561-7fe3-4325-b5dc-c58f2d9b8a27"), Nome= "Manacapuru"},
                new Regiao {Id=Guid.Parse("8e462a08-2a90-4261-b007-e3652ea74764"), Nome= "Presidente Figuereido"},
                new Regiao {Id=Guid.Parse("4249ae61-c978-4c30-a8d6-5a6dec597325"), Nome= "Iranduba"}
            }; 

            //colocando dados de regioes
            modelBuilder.Entity<Regiao>().HasData(regions);

            modelBuilder.Entity<ComentarioPraia>().HasKey(e => e.Id);
            modelBuilder.Entity<RespostaComentarioPraia>().HasKey(e => e.Id);

            modelBuilder.Entity<Praia>().Property(a => a.Nota).HasColumnType("decimal(3,1)");

        }
    }
}
