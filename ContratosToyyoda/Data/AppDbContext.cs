using ContratosToyyoda.Models;
using Microsoft.EntityFrameworkCore;

namespace ContratosToyyoda.Data

{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

      

        public DbSet<Contrato> contratos { get; set; }
        public DbSet<Pais> paises { get; set; }
  
        public DbSet<Usuario> usuarios { get; set; }

    }
}
