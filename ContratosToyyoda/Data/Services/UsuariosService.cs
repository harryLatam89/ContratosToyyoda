using ContratosToyyoda.Data.Base;
using ContratosToyyoda.Models;
using Microsoft.EntityFrameworkCore;

namespace ContratosToyyoda.Data.Services
{
    public class UsuariosService : EntityBaseRepository<Usuario>, IUsuariosService
    {
   
       

        public UsuariosService(AppDbContext context): base(context)
        {
        
        }
        
    }
}
