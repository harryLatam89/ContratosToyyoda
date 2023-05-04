using System.ComponentModel.DataAnnotations;

namespace ContratosToyyoda.Models
{
    public class Empresa
    {
        [Key]
        public int idEmpresa { get; set; }

        public string nombre { get; set; }

        public string direccion { get; set; }

        public string logoUrl { get; set;}

        public string idPais { get; set;}
    }
}
