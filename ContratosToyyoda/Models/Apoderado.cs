using ContratosToyyoda.Data;
using ContratosToyyoda.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContratosToyyoda.Models
{
    public class Apoderado : Persona
    {

        public ICollection<Pais> paises { get; set; }
    }
}
