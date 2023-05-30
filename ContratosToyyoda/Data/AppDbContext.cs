using ContratosToyyoda.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ContratosToyyoda.Data

{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
               {
            base.OnModelCreating(modelBuilder);
        }
            
    

      

        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Pais> Paises { get; set; }
  
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Apoderado> Apoderados { get; set; }

    }
}
