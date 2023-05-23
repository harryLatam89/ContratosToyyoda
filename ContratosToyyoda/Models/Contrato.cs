using ContratosToyyoda.Data;
using ContratosToyyoda.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ContratosToyyoda.Models
{
    public class Contrato:IEntityBase
    {
        [Key]
      
        public int Id  { get; set; }

        [Display(Name = "NOMBRE")]
        public string nombre { get; set;}

        [Display(Name = "APELLIDO")]
        public string apellido { get; set; }

        [Display(Name = "SUELDO")]
        public double sueldo { get; set; }

        [Display(Name = "TIPO CONTRATO")]
        public TipoContrato tipoContrato { get; set;}

        [Display(Name = "FECHA INGRESO")]
        public DateTime fechaIngreso { get; set; }

        [Display(Name = "FECHA EMISION")]
        public DateTime fechaEmision { get; set; }

        [Display(Name = "email")]
        public string email { get; set; }        
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
    }
    
}
