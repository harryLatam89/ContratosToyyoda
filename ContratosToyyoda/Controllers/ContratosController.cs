using Azure;
using ContratosToyyoda.Data;
using ContratosToyyoda.Data.Services;
using ContratosToyyoda.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using Microsoft.AspNetCore.Hosting;
using ContratosToyyoda.Data.ViewModels;
using System.IO;
using System.Threading.Tasks;
using Xceed.Words.NET;
using System.Xml.Linq;
using System.IO;
using Aspose.Words;
using Aspose.Words.Saving;


namespace ContratosToyyoda.Controllers
{
    
    public class ContratosController : Controller
    {
        private readonly IContratosService _service;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ContratosController(IContratosService service, IWebHostEnvironment webHostEnvironment)
        {
            _service = service;
            _webHostEnvironment = webHostEnvironment;

        }
        public async Task<IActionResult> Index()
        {
            var allContratos = await _service.GetAllAsync(n => n.pais);
            var contratosMenus = await _service.GetNuevoMenusValores();
            ViewBag.Usuarios = new SelectList(contratosMenus.Usuarios, "id", "nombreUsuario");
            ViewBag.Paises = new SelectList(contratosMenus.Paises, "id", "pais");
            foreach (var item in ViewBag.Usuarios.Items)
            {
                Console.WriteLine($"nombre: {item.nombreUsuario}, apellido: {item.apellido}");
            }
            Console.WriteLine($"nombre: {ViewBag.Usuarios.Items}");
            return View(allContratos);
        }

        //GET: Contratos/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var contratoDetalles = await _service.GetContratoByIdAsync(id);
            return View(contratoDetalles);
        }

        // GET 

        public async Task<IActionResult> Create()
        {

            var contratosMenus = await _service.GetNuevoMenusValores();

            var usuariosSelectList = contratosMenus.Usuarios.Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.nombreUsuario });
            ViewBag.Usuarios = usuariosSelectList;
            var paisesSelectList = contratosMenus.Paises.Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.pais });
            ViewBag.Paises = paisesSelectList;

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(NuevoContratoVM contrato)
        {
            if (!ModelState.IsValid)
            {
                var contratosMenus = await _service.GetNuevoMenusValores();

                var usuariosSelectList = contratosMenus.Usuarios.Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.nombreUsuario });
                ViewBag.Usuarios = usuariosSelectList;
                var paisesSelectList = contratosMenus.Paises.Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.pais });
                ViewBag.Paises = paisesSelectList;
                return View(contrato);
            }

            await _service.AddNuevoContratoAsync(contrato);
            return RedirectToAction(nameof(Index));
        }



        //Get contrato/Edit/1
        [AllowAnonymous]
        public async Task<IActionResult> Edit(int id)
        {



            var contratodetalles = await _service.GetContratoByIdAsync(id);
            if (contratodetalles == null) return View("NotFound");

            var response = new NuevoContratoVM()
            {
                id = contratodetalles.Id,
                nombre = contratodetalles.nombre,
                apellido = contratodetalles.apellido,
                tipoContrato = contratodetalles.tipoContrato,
                sueldo = contratodetalles.sueldo,
                idPais = contratodetalles.idPais,
                idUser = contratodetalles.idUser,
                fechaEmision = contratodetalles.fechaEmision,
                fechaIngreso = contratodetalles.fechaIngreso,
            };

            var contratosMenus = await _service.GetNuevoMenusValores();

            var usuariosSelectList = contratosMenus.Usuarios.Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.nombreUsuario });
            ViewBag.Usuarios = usuariosSelectList;
            var paisesSelectList = contratosMenus.Paises.Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.pais });
            ViewBag.Paises = paisesSelectList;
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NuevoContratoVM contrato)
        {
            if (id != contrato.id) return View("NotFound");



            if (!ModelState.IsValid)
            {
                var contratosMenus = await _service.GetNuevoMenusValores();

                var usuariosSelectList = contratosMenus.Usuarios.Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.nombreUsuario });
                ViewBag.Usuarios = usuariosSelectList;
                var paisesSelectList = contratosMenus.Paises.Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.pais });
                ViewBag.Paises = paisesSelectList;
                return View(contrato);
            }

            await _service.UpdateContratoAsync(contrato);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Multiple()
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Multiple(IFormFile fileInput)
        {
            List<NuevoContratoVM> contratos = new List<NuevoContratoVM>();

            if (fileInput != null && fileInput.Length > 0)
            {
                using (var reader = new StreamReader(fileInput.OpenReadStream()))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        if (values.Length >= 5) // Asegurar que haya suficientes campos en el registro
                        {

                            string nombre = values[0];                                                      
                            string apellido = values[1];                           
                            string sueldoStr = values[2];
                            string tipoContratoStr = values[3]; 
                            string fechaIngresoStr = values[4];
                            string fechaEmisionStr = values[5];
                            string idPaisStr = values[6];
                            string idUserStr = values[7];

                            if (Enum.TryParse(tipoContratoStr, out TipoContrato tipoContrato)) {
                              
                                if (double.TryParse(sueldoStr, out double sueldo)) {
                                 

                                    if (int.TryParse(idPaisStr, out int idPais)) {
                                  
                                        if (int.TryParse(idPaisStr, out int idUser)) {
                                         
                                            if (DateTime.TryParseExact(fechaEmisionStr, "dd/MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaEmision)) {
                                               
                                                if ( DateTime.TryParseExact(fechaIngresoStr, "dd/MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaIngreso))

                                                   {
                                                    // Crear un nuevo objeto y agregarlo a la lista
                                                 
                                                    var nuevoContrato = new NuevoContratoVM
                                                    {
                                                        nombre = nombre,
                                                        apellido = apellido,
                                                        tipoContrato = tipoContrato,
                                                        sueldo = sueldo,
                                                        idPais = idPais,
                                                        idUser = idUser,
                                                        fechaEmision = fechaEmision,
                                                        fechaIngreso = fechaIngreso
                                                    };
                                                    await _service.AddNuevoContratoAsync(nuevoContrato);
                                                }
                                            }
                                        }
                                    }

                                }


                            }


                            else
                            {
                                Console.WriteLine("Manejar el caso cuando la conversión de datos falla para un registro");
                                // Manejar el caso cuando la conversión de datos falla para un registro
                                // Puedes agregar un registro de error, mostrar un mensaje de error, etc.
                            }
                        }
                        else
                        {
                            Console.WriteLine(" Manejar el caso cuando el registro no tiene suficientes campos");
                            // Manejar el caso cuando el registro no tiene suficientes campos
                            // Puedes agregar un registro de error, mostrar un mensaje de error, etc.
                        }
                    }




                    
                }


            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Plantilla()
        {


            return View();
        }

        

        [HttpPost]
        public async Task<IActionResult> Plantilla(IFormFile fileInput)
        {
            string filePath;

            if (fileInput != null && fileInput.Length > 0)
                {
                Console.WriteLine(_webHostEnvironment.WebRootPath);
                Console.WriteLine(fileInput.FileName);
                filePath = Path.Combine(_webHostEnvironment.WebRootPath + "/Plantilla/",fileInput.FileName);
                Console.WriteLine("Concatela la cadena *********");
                Console.WriteLine(filePath);
                using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        fileInput.CopyTo(stream);
                    }
                }
            
            else
            {

            }

            filePath = Path.Combine(_webHostEnvironment.WebRootPath + "/Plantilla/", fileInput.FileName);

            // Pasar la ruta del archivo a la vista mediante el modelo
            var model = new PlantillaViewModel(filePath);
            string fileContent = System.IO.File.ReadAllText(filePath);
            ViewBag.FileContent = fileContent;

            return View(model);
        }


        [AllowAnonymous]
        public async Task<IActionResult> Imprimir(int id)
        {
           // Obtener los datos del contrato desde la base de datos
            var contratodetalles = await _service.GetContratoByIdAsync(id);
            string filePath = "C:/Development/ContratosToyyoda/ContratosToyyoda/wwwroot/Plantilla/CONTRATO DE EMPLEO PLANTILLA.docx";
            // Ruta de la plantilla de Word

            // Cargar la plantilla de Word
            DocX doc;
            doc = DocX.Load(filePath);
            Console.WriteLine(contratodetalles.nombre);
            // Reemplazar los marcadores de posición en la plantilla con los datos del contrato
            doc.ReplaceText("[nombre]", contratodetalles.nombre);
            doc.ReplaceText("[apellido]", contratodetalles.apellido);
            doc.ReplaceText("[tipoContrato]", contratodetalles.tipoContrato.ToString());
            doc.ReplaceText("[sueldo]", contratodetalles.sueldo.ToString());
            doc.ReplaceText("[idPais]", contratodetalles.idPais.ToString());
            doc.ReplaceText("[idUser]", contratodetalles.idUser.ToString());
            doc.ReplaceText("[fechaEmision]", contratodetalles.fechaEmision.ToString("dd/MM/yyyy"));
            doc.ReplaceText("[fechaIngreso]", contratodetalles.fechaIngreso.ToString("dd/MM/yyyy"));
            // Guardar el documento modificado en una ubicación temporal
            string rutaTemporal = Path.Combine(Path.GetTempPath(), "contrato_temp.docx");
            doc.SaveAs(rutaTemporal);
            string idstr = contratodetalles.Id.ToString();
            // Generar el archivo PDF a partir del documento Word modificado
            string rutaPdf = Path.Combine("C:/Development/ContratosToyyoda/ContratosToyyoda/wwwroot/Contratos/", idstr+".pdf");
            Console.WriteLine(rutaPdf);

            // Load the word file to be converted to PDF
            Document sampleDocx = new Document(rutaTemporal);

            // Instantiate the PdfSaveOptions class object before converting the Docx to PDF
            PdfSaveOptions options = new PdfSaveOptions();

            // Set page mode to full screen while opening it in a viewer
            options.PageMode = PdfPageMode.FullScreen;

            // Set the output PDF document compliance mode
            options.Compliance = PdfCompliance.Pdf17;

            // Save the resultant PDF file using the above mentioned options
            sampleDocx.Save(rutaPdf, options);

            //borramos el arhivo de word temporal 

            System.IO.File.Delete(rutaTemporal);


            return RedirectToAction(nameof(AbrirArchivoPDF), new { rutaArchivo = rutaPdf });
        }

        public IActionResult AbrirArchivoPDF(string rutaArchivo)
        {
            // Obtener el nombre del archivo sin la ruta
            string nombreArchivo = Path.GetFileName(rutaArchivo);

            // Leer el archivo en bytes
            byte[] contenidoArchivo = System.IO.File.ReadAllBytes(rutaArchivo);

            // Configurar el encabezado de respuesta
            Response.Headers.Add("Content-Disposition", $"inline; filename={nombreArchivo}");
            Response.Headers.Add("Content-Type", "application/pdf");

            // Devolver el contenido del archivo como un archivo PDF
            return File(contenidoArchivo, "application/pdf");
        }




    }
}

