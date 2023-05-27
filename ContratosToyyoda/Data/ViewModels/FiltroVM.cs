using System.ComponentModel.DataAnnotations;

namespace ContratosToyyoda.Data.ViewModels
{
    public class FiltroVM
    {
        [Display(Name = "Opciones")]
        [Required(ErrorMessage = "una opcion es obligatoria")]
        public string opcion { get; set; }
    }
}
