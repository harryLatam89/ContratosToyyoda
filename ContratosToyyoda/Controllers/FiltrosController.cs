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
           
            var nombresPaises = await _context.Paises.Select(p => p.pais).ToListAsync();
            var paisesSelectList = nombresPaises.Select(p => new SelectListItem { Value = p, Text = p }).ToList();
            ViewBag.Paises = paisesSelectList;

            return View();
         
        }
        
        public async Task<IActionResult> PorPais(string paisSeleccionado)
        {
            paisSeleccionado = "El Salvador";
            var allPaises = await _servicePaises.GetAllAsync();

            int IdSelected=0 ; // Variable para almacenar la contraseña
            
            foreach (var paisItem in allPaises)
            {
                Console.WriteLine("Id del del pais :" + IdSelected + "paisItem.pais  :" + paisItem.pais + "  paisesDropdown  :" + paisSeleccionado);
                if (paisItem.pais == "El Salvador")
                {
                    
                    IdSelected =paisItem.Id;
                   
                    break; // Se encontró el usuario, se sale del bucle
                }
            };
          
            var contratos = await _context.Contratos
    .Where(c => c.idPais == 1)
    .ToListAsync();

            return View("~/Views/Contratos/Index.cshtml", contratos);
        }
    }
}
