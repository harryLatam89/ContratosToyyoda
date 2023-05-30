using ContratosToyyoda.Data.Base;
using ContratosToyyoda.Data.ViewModels;
using ContratosToyyoda.Models;

namespace ContratosToyyoda.Data.Services
{
    public interface IPaisesService: IEntityBaseRepository<Pais>
    {
        Task<PaisMenuVM> GetNuevoMenusValores();

        Task AddPaisAsync(PaisVM dato);

        Task<Pais> GetPaisByIdAsync(int id);
        
        Task UpdatePaisAsync(PaisVM dato);
    }
}
