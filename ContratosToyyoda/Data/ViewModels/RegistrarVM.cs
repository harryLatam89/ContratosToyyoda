using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;




namespace ContratosToyyoda.Data.ViewModels
{
    public class RegistrarVM
    {
        [Display(Name = "Nombre Completo")]
        [Required(ErrorMessage = "Nombre es requerido")]
        public string FullName { get; set; }

        [Display(Name = "Correo Electronico")]
        [Required(ErrorMessage = "Correo electronico es requerido")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirme Contrasena")]
        [Required(ErrorMessage = "Confirmar Contrasena es requerido")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Contrasena no coincide")]
        public string ConfirmPassword { get; set; }
    }
}
