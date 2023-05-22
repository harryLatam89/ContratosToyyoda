using System.ComponentModel.DataAnnotations;

namespace ContratosToyyoda.Data.ViewModels
{
    public class LoginVM
    {
        [Display (Name ="Correo Electronico")]
        [Required (ErrorMessage = "Correo electronico es requerido")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType (DataType.Password)]
        [Display(Name = "Contrasena")]
        public string Password { get; set; }    
    }
}
