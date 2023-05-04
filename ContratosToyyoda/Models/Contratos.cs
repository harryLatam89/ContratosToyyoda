using ContratosToyyoda.Data;
using System.ComponentModel.DataAnnotations;

namespace ContratosToyyoda.Models
{
    public class Contratos
    {
        [Key]
        public int idContrato  { get; set; }

        public string nombre { get; set;}

        public string apellido { get; set; }

        public double sueldo { get; set; }

        public TipoContrato tipoContrato { get; set;}

        public DateOnly fechaIngreso { get; set; }

        public DateOnly fechaEmision { get; set; }

        public int idUser { get; set; }

        public int idPais { get; set; }

        public int idEmpresa { get; set; }
    }
    
}
