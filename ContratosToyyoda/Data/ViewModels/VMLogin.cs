using System.ComponentModel.DataAnnotations;

namespace ContratosToyyoda.Data.ViewModels
{
    public class VMLogin
    {
        [Display(Name = "EMAIL")]
        public string Email { get; set; }
        [Display(Name = "CONTRASAÑA")]
        public string PassWord { get; set; }
        [Display(Name = "MANTENER LA SESION INICIADA")]
        public bool KeepLoggedIn { get; set; }
    }
}
