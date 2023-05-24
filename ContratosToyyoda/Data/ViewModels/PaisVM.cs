using ContratosToyyoda.Data.Base;
using ContratosToyyoda.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ContratosToyyoda.Data.ViewModels
{
    public class PaisVM
    {

       


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
            public IFormFile? fileInput { get; set; }

        
    }
}
