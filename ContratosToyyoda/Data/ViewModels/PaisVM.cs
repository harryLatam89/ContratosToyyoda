using System.ComponentModel.DataAnnotations;

namespace ContratosToyyoda.Data
{
    public class PaisVM
    {
  
        public int id { get; set; }

        [Display(Name = "PAIS")]
        [Required(ErrorMessage = "nombre de pais es obligatorio")]
        public string pais { get; set; }

        [Display(Name = "REGION")]
        [Required(ErrorMessage = "region es obligatorio")]
        public string region { get; set; }

        [Display(Name = "DIRECCION")]
        [Required(ErrorMessage = "direccion es obligatorio")]
        public string direccion { get; set; }

        [Display(Name = "LOGO")]
        [Required(ErrorMessage = "Un logo es obligatorio")]
        public string logo { get; set; }

        //relaciones 

        // con APODERADO
        [Display(Name = "APODERADO")]
        public int idApoderado { get; set; }
    }
}
