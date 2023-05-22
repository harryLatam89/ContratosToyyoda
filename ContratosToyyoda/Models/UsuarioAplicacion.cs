using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ContratosToyyoda.Models
{
    public class UsuarioAplicacion : IdentityUser
    {

        [Display (Name="Nombre Completo")]
        public string FullName { get; set; }  
    }
}
