using ContratosToyyoda.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContratosToyyoda.Models
{
    public class Contrato
    {
        [Key]

        public int id  { get; set; }

        public string nombre { get; set;}

        public string apellido { get; set; }

        public double sueldo { get; set; }

        public TipoContrato tipoContrato { get; set;}

        public DateOnly fechaIngreso { get; set; }

        public DateOnly fechaEmision { get; set; }

        //relaciones 

        // con user
        public int idUser { get; set; }
        [ForeignKey("idUser")]

        public Usuario usuario { get; set; }
    
        // compresa 
        public int idPais { get; set; }
        [ForeignKey("idPais")]
        public Pais pais { get; set; }
    }
    
}
