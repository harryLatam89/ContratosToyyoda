﻿using ContratosToyyoda.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContratosToyyoda.Models
{
    public class Pais: IEntityBase
    {
        [Key]
        public int Id { get; set; }

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
        [ForeignKey("idApoderado")]
        public Apoderado apoderado { get; set; }

        public ICollection<Contrato> contratos { get; set; }
    }
}
