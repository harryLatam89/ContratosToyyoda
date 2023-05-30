using ContratosToyyoda.Data.Base;
using ContratosToyyoda.Models;

namespace ContratosToyyoda.Data.Services
{
    public class ApoderadosService: EntityBaseRepository<Apoderado>, IApoderadosService
    {
        public ApoderadosService(AppDbContext context) : base(context)
        {

        }
    }
}
