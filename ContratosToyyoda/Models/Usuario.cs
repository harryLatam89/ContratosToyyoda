﻿using ContratosToyyoda.Data.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace ContratosToyyoda.Models
{
    public class Usuario:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "CORREO")]
        public string email { get; set; }

        [Display(Name = "NOMBRE")]
        [Required(ErrorMessage = "nombre es obligatorio")]
        public string nombre { get; set; }

        [Display(Name = "APELLIDO")]
        [Required(ErrorMessage = "apellido es obligatorio")]
        public string apellido { get; set; }

        [Display(Name = "CONTRASEÑA")]
        [Required(ErrorMessage = "una contraseña es obligatorio")]
        public string contrasena { get; set; }

        [Display(Name = "ROL")]
               public string rol { get; set; }

        public ICollection<Contrato> contratos { get; set; }


    }
}
