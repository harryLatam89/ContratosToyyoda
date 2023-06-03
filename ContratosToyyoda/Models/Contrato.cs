using ContratosToyyoda.Data;
using ContratosToyyoda.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ContratosToyyoda.Models
{
    public class Contrato: Persona
    {
       
        [Display(Name = "SUELDO")]
        public double sueldo { get; set; }

        [Display(Name = "TIPO CONTRATO")]
        public TipoContrato tipoContrato { get; set;}

        [Display(Name = "FECHA INGRESO")]
        public DateTime fechaIngreso { get; set; }

        [Display(Name = "FECHA EMISION")]
        public DateTime fechaEmision { get; set; }

        [Display(Name = "Cargo")]
        public string cargo { get; set; }
        /// <summary>
        /// Recien agreaados , inactivo y fecha Fin 
        /// </summary>
        [Display(Name = "ESTA INACTIVO")]
        public bool inactivo { get; set; }

        [Display(Name = "FECHA FIN DE CONTRATO")]
        public DateTime? fechaFin { get; set; }

        //relaciones 

        // con user
        [Display(Name = "CREADO POR")]
        public int idUser { get; set; }
        [ForeignKey("idUser")]

        public Usuario usuario { get; set; }

        // compresa 
        [Display(Name = "PAIS SEDE")]
        public int idPais { get; set; }
        [ForeignKey("idPais")]
        public Pais pais { get; set; }




        /////////////////////////////////////////////////////   



    }
    
}
