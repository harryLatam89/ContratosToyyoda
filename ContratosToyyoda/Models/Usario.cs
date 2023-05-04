﻿using System.ComponentModel.DataAnnotations;

namespace ContratosToyyoda.Models
{
    public class Usario
    {
        [Key]
        public int idUsuario { get; set; }

        public string nombreUsuario { get; set;}

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string contrasena { get; set; }
    }
}
