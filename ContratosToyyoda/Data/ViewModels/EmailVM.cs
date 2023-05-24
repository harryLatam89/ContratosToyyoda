using System.ComponentModel.DataAnnotations;

namespace ContratosToyyoda.Data.ViewModels
{
    public class EmailVM
    {

        public int idContrato { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "nombre de pais es obligatorio")]
        public string email { get; set; }

        [Display(Name = "Asunto")]
        [Required(ErrorMessage = "region es obligatorio")]
        public string asunto { get; set; }

        [Display(Name = "Mensaje")]
        [Required(ErrorMessage = "direccion es obligatorio")]
        public string mensaje { get; set; }


   
    }
}
