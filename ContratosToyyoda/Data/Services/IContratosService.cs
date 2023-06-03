using ContratosToyyoda.Data.Base;
using ContratosToyyoda.Data.ViewModels;
using ContratosToyyoda.Models;

namespace ContratosToyyoda.Data.Services
{
    public interface IContratosService:IEntityBaseRepository<Contrato>
    {
        Task<Contrato> GetContratoByIdAsync(int id);

        Task<NuevoContratoMenusVM> GetNuevoMenusValores();

        Task AddNuevoContratoAsync(NuevoContratoVM dato);

        
        Task UpdateContratoAsync(NuevoContratoVM dato);

        Task<Contrato> GetContratoByEmailAsync(string email);

        Task<List<Contrato>> GetContratosActivosAsync();

        Task<List<Contrato>> GetContratosInactivosAsync();
    }
}
