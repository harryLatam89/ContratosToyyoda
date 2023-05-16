using ContratosToyyoda.Controllers;
using ContratosToyyoda.Models;

namespace ContratosToyyoda.Data.ViewModels
{
    public class NuevoContratoMenusVM
    {
        public NuevoContratoMenusVM()
        {
            Usuarios = new List<Usuario>();
            Paises = new List<Pais>();
        }
        public List<Usuario> Usuarios { get; set; }
        public List<Pais> Paises { get; set; }  


    }
}
