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
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath + "/Plantilla");
            string[] archivos = Directory.GetFiles(filePath);
            string[] nombres = new string[archivos.Length];




            for (int i = 0; i < archivos.Length; i++)
            {
                nombres[i] = Path.GetFileName(archivos[i]);
            }

            return View(nombres);
        }


        [HttpPost]
        public async Task<IActionResult> Plantilla(PlantillaViewModel plantilla)
        {
            string filePath;

            if (plantilla.fileInput != null && plantilla.fileInput.Length > 0)
            {

                if (plantilla.tipoContrato == TipoContrato.temporal)
                {
                    filePath = Path.Combine(_webHostEnvironment.WebRootPath + "/Plantilla/Temporal.docx");
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        plantilla.fileInput.CopyTo(stream);
                    }
                }


                else
                {
                    filePath = Path.Combine(_webHostEnvironment.WebRootPath + "/Plantilla/Permanente.docx");
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
