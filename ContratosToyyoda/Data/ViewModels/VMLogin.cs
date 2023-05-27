using System.ComponentModel.DataAnnotations;

namespace ContratosToyyoda.Data.ViewModels
{
    public class VMLogin
    {
        [Display(Name = "EMAIL")]
        [Required(ErrorMessage = "Un correo es obligatorio")]
        public string Email { get; set; }
        [Display(Name = "CONTRASEÑA")]
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string PassWord { get; set; }
        [Display(Name = "MANTENER LA SESION INICIADA")]
        public bool KeepLoggedIn { get; set; }
    }
}
