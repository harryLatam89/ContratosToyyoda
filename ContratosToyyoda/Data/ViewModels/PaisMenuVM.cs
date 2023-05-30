using ContratosToyyoda.Models;

namespace ContratosToyyoda.Data.ViewModels
{
    public class PaisMenuVM
    {
        public PaisMenuVM()
        {
            
            Apoderados = new List<Apoderado>();
        }
        public List<Apoderado> Apoderados { get; set; }
       

    }
}
