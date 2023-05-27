using ContratosToyyoda.Data;
using ContratosToyyoda.Data.Services;
using ContratosToyyoda.Data.ViewModels;
using ContratosToyyoda.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ContratosToyyoda.Controllers
{
    public class FiltrosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPaisesService _servicePaises;
        private readonly IContratosService _serviceContratos;
        public FiltrosController(AppDbContext dbContext, IContratosService serviceContratos, IPaisesService servicePaises)
        {
            _context = dbContext;
            _serviceContratos = serviceContratos;
            _servicePaises = servicePaises;

        }



        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var contratosMenus = await _serviceContratos.GetNuevoMenusValores();
            var usuariosSelectList = contratosMenus.Usuarios.Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.email });
            ViewBag.Usuarios = usuariosSelectList;
            var paisesSelectList = contratosMenus.Paises.Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.pais });
            ViewBag.Paises = paisesSelectList;

              return View();
         
        }
        [HttpPost]
      
        public async Task<IActionResult> PorPais([Bind("opcion")] FiltroVM dato)

        {
            
            var contratos = await _context.Contratos
    .Where(c => c.idPais.ToString() == dato.opcion)
    .ToListAsync();

            var contratosMenus = await _serviceContratos.GetNuevoMenusValores();
            ViewBag.Usuarios = new SelectList(contratosMenus.Usuarios, "id", "nombreUsuario");
            ViewBag.Paises = new SelectList(contratosMenus.Paises, "id", "pais");
            foreach (var item in ViewBag.Usuarios.Items)
            {
                Console.WriteLine($"nombre: {item.email}, apellido: {item.apellido}");
            }

            //"~/Views/Contratos/Index.cshtml", contratos
            return View("~/Views/Contratos/Index.cshtml", contratos);
        }

        [HttpPost]

        public async Task<IActionResult> CreadoPor([Bind("opcion")] FiltroVM dato)

        {
            
            var contratos = await _context.Contratos
    .Where(c => c.idUser.ToString() == dato.opcion)
    .ToListAsync();
            var contratosMenus = await _serviceContratos.GetNuevoMenusValores();
            ViewBag.Usuarios = new SelectList(contratosMenus.Usuarios, "id", "nombreUsuario");
            ViewBag.Paises = new SelectList(contratosMenus.Paises, "id", "pais");
            foreach (var item in ViewBag.Usuarios.Items)
            {
                Console.WriteLine($"nombre: {item.email}, apellido: {item.apellido}");
            }

            //"~/Views/Contratos/Index.cshtml", contratos
            return View("~/Views/Contratos/Index.cshtml", contratos);
        }
    }
}
