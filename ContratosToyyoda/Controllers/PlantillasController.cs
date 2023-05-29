using ContratosToyyoda.Data.Services;
using Microsoft.AspNetCore.Mvc;
using ContratosToyyoda.Data;
using ContratosToyyoda.Data.ViewModels;

namespace ContratosToyyoda.Controllers
{
    public class PlantillasController : Controller
    {
        private readonly IContratosService _service;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PlantillasController(IContratosService service, IWebHostEnvironment webHostEnvironment)
        {
            _service = service;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Plantilla()
        {



            return View();
        }


        public async Task<IActionResult> ListaPlantillas()
        {
           
            return View();
        }

        public IActionResult DPermanente()
        {

            string filePath = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/Plantilla/Permanente.docx");
            string nombreArchivo = "plantillaPermante.docx";
            string tipoContenido = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

            if (System.IO.File.Exists(filePath))
            {
                return File(System.IO.File.ReadAllBytes(filePath), tipoContenido, nombreArchivo);
            }
            else
            {
                // Archivo no encontrado, puedes retornar una vista de error o realizar alguna otra acción.
                return NotFound();
            }

            
        }

            public IActionResult DTemporal()
        {
                
                string filePath = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/Plantilla/Temporal.docx");
                string nombreArchivo = "plantillaTemporal.docx";
            string tipoContenido = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

            if (System.IO.File.Exists(filePath))
            {
                return File(System.IO.File.ReadAllBytes(filePath), tipoContenido, nombreArchivo);
            }
            else
            {
                // Archivo no encontrado, puedes retornar una vista de error o realizar alguna otra acción.
                return NotFound();
            }
            
        }

        public IActionResult DescargarCSV()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory()+ "/wwwroot/PlantillaContratos/contratos.csv");
            string nombreArchivo = "PlantillaContratos.csv";
            string tipoContenido = "text/csv";

            if (System.IO.File.Exists(filePath))
            {
                return File(System.IO.File.ReadAllBytes(filePath), tipoContenido, nombreArchivo);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Plantilla(PlantillaViewModel plantilla)
        {
            string filePath;

            if (plantilla.fileInput != null && plantilla.fileInput.Length > 0)
            {

                if (plantilla.tipoContrato == TipoContrato.temporal)
                {
                    filePath = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/Plantilla/Temporal.docx");
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        plantilla.fileInput.CopyTo(stream);
                    }
                }


                else
                {
                    filePath = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/Plantilla/Permanente.docx");
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        plantilla.fileInput.CopyTo(stream);
                    }
                }

            }



            return View("CargaExitosa");
        }




        public IActionResult Index()
        {
            return View();
        }
    }
}
