using ContratosToyyoda.Data.Base;
using ContratosToyyoda.Models;

namespace ContratosToyyoda.Data.Services
{
    public class PaisesService: EntityBaseRepository<Pais>, IPaisesService
    {
        public PaisesService(AppDbContext context):base (context)
        {
            
        }
    }
}
