using Microsoft.EntityFrameworkCore;

namespace ContratosToyyoda.Data

{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
    }
}
