using System.ComponentModel.DataAnnotations;

namespace ContratosToyyoda.Models
{
    public class Pais
    {
        [Key]
        public int idPais { get; set; }

        public int nombre { get; set; }

        public int region { get; set; }
    }
}
