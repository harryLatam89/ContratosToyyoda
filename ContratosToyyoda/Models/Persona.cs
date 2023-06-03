using ContratosToyyoda.Data.Base;
using ContratosToyyoda.Data;
using ContratosToyyoda.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContratosToyyoda.Models
{
    public class Persona : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "NOMBRE")]
        public string nombre { get; set; }

        [Display(Name = "APELLIDO")]
        public string apellido { get; set; }

        [Display(Name = "EMAIL")]
        public string email { get; set; }

        [Display(Name = "SEXO")]
        public Sexo sexo { get; set; }

        [Display(Name = "ESTADO FAMILIAR")]
        public EstadoFamiliar estadoFamiliar { get; set; }

        [Display(Name = "PROFESION")]
        public string profesion { get; set; }

        [Display(Name = "Domicilio")]
        public string domicilio { get; set; }

        [Display(Name = "Nacionalidad")]
        public string nacionalidad { get; set; }

        [Display(Name = "tipo de Documento")]
        public string TipoDoc { get; set; }

        [Display(Name = "Numero Documento")]
        public string numDocId { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        public DateTime fechaNacimiento { get; set; }
    }
}
