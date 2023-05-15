using ContratosToyyoda.Data.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace ContratosToyyoda.Models
{
    public class Usuario:IEntityBase
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "USUARIO")]
        [Required(ErrorMessage ="nombre de usuario es obligatorio")]
        public string nombreUsuario { get; set;}

        [Display(Name = "NOMBRE")]
        [Required(ErrorMessage = "nombre es obligatorio")]
        public string nombre { get; set; }

        [Display(Name = "APELLIDO")]
        [Required(ErrorMessage = "apellido es obligatorio")]
        public string apellido { get; set; }

        [Display(Name = "CONTRASEÑA")]
        [Required(ErrorMessage = "una contraseña es obligatorio")]
        public string contrasena { get; set; }



    }
}
