using Azure;
using ContratosToyyoda.Data;
using ContratosToyyoda.Data.Services;
using ContratosToyyoda.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            var allContratos = await _service.GetAllAsync(n =>n.pais);
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

       public async Task<IActionResult> Create() {

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



        
    }
}
