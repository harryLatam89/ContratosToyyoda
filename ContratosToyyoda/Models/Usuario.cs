using System.ComponentModel.DataAnnotations;

namespace ContratosToyyoda.Models
{
    public class Usuario
    {
        [Key]
        public int id { get; set; }

        public string nombreUsuario { get; set;}

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string contrasena { get; set; }

        //Relaciones de modelos
        public List<Contrato> contratos { get; set; }   

    }
}
