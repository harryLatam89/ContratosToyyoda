using ContratosToyyoda.Data;
using ContratosToyyoda.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace ContratosToyyoda.Models
{
    public class NuevoContratoVM
    { 
        public int id { get; set; }

        [Required(ErrorMessage ="nombre es requerido")]
        [Display(Name = "NOMBRE")]
        public string nombre { get; set;}
        [Required(ErrorMessage = "apellido es requerido")]
        [Display(Name = "APELLIDO")]
        public string apellido { get; set; }

        [Required(ErrorMessage = "email es requerido")]
        [Display(Name = "email")]
        public string email { get; set; }

        [Required(ErrorMessage = "sueldo es requerido")]
        [Display(Name = "SUELDO")]
        public double sueldo { get; set; }
        [Required(ErrorMessage = "tipo de contrato es requerido")]
        [Display(Name = "TIPO CONTRATO")]
        public TipoContrato tipoContrato { get; set;}
        [Required(ErrorMessage = "fecha de ingreso es requerido")]

        [Display(Name = "FECHA INGRESO")]
        public DateTime fechaIngreso { get; set; }
        [Required(ErrorMessage = "fecha de emision es requerido")]

        [Display(Name = "FECHA EMISION")]
        public DateTime fechaEmision { get; set; }
        [Required(ErrorMessage = "este campo es requerido")]
        [Display(Name = "CREADO POR")]
        public int idUser { get; set; }

        [Required(ErrorMessage = "pais es requerido")]
        [Display(Name = "PAIS SEDE")]
        public int idPais { get; set; }
       
    }
    
}
