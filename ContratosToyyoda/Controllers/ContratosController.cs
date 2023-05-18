using Azure;
using ContratosToyyoda.Data;
using ContratosToyyoda.Data.Services;
using ContratosToyyoda.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
using System;
using System.Diagnostics.Contracts;
using System.Globalization;

namespace ContratosToyyoda.Controllers
{
    public class ContratosController : Controller
    {
        private readonly IContratosService _service;

        public ContratosController(IContratosService service)
        {
            _service = service;
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
                            Console.WriteLine(" Convirtio sueldo en  " + sueldoStr);
                            string fechaIngresoStr = values[4];
                            string fechaEmisionStr = values[5];

                            string idPaisStr = values[6];
                            string idUserStr = values[7];

                            if (Enum.TryParse(tipoContratoStr, out TipoContrato tipoContrato)) {
                                Console.WriteLine(" Convirtio tipo contrato ");
                                
                                if (double.TryParse(sueldoStr, out double sueldo)) {
                                    Console.WriteLine(" Convirtio Sueldo ");

                                    if (int.TryParse(idPaisStr, out int idPais)) {
                                        Console.WriteLine(" Convirtio Pais ");
                                        if (int.TryParse(idPaisStr, out int idUser)) {
                                           Console.WriteLine(" Convirtio ID user  ");
                                            if (DateTime.TryParseExact(fechaEmisionStr, "dd/MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaEmision)) {
                                                Console.WriteLine(" Convirtio  fechaEmisionStr  ");
                                                if ( DateTime.TryParseExact(fechaIngresoStr, "dd/MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaIngreso))

                                                   {
                                                    // Crear un nuevo objeto y agregarlo a la lista
                                                    Console.WriteLine(" Convirtio  fechaIngresoStr  ");
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



                    foreach (var contrato in contratos)
                    {
                        Console.WriteLine($"Nombre: {contrato.nombre}");
                        Console.WriteLine($"Fecha: {contrato.fechaEmision}");
                        Console.WriteLine($"Sueldo: {contrato.sueldo}");
                        Console.WriteLine($"IdPaisOrigen: {contrato.idPais}");
                        Console.WriteLine();
                    }

                    
                }


            }
            return RedirectToAction(nameof(Index));
        }
    }
}

