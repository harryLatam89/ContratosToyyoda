using System.ComponentModel.DataAnnotations;

namespace ContratosToyyoda.Models
{
    public class Pais
    {
        [Key]
        public int id { get; set; }

        public string pais { get; set; }

        public string region { get; set; }

        public string direccion { get; set; }
        
        public string logoUrl { get; set; }

    }
}
