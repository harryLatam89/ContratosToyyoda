using ContratosToyyoda.Data.Base;
using ContratosToyyoda.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContratosToyyoda.Data.ViewModels

{
    public class PlantillaViewModel
    {
        [Required(ErrorMessage = "Archivo es requerido")]
        [Display(Name = "ARCHIVO DE PLANTILLA")]
        public IFormFile? fileInput { get; set; }

        [Required(ErrorMessage = "Tìpo de contrato es requerido")]
        [Display(Name = "TIPO DE CONTRATO")]
        public TipoContrato tipoContrato { get; set; }
    }
}
