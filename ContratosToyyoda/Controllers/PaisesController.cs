using ContratosToyyoda.Data;
using ContratosToyyoda.Data.Services;
using ContratosToyyoda.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ContratosToyyoda.Data.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Contracts;
using Azure;

namespace ContratosToyyoda.Controllers
{
    public class PaisesController : Controller
    {
        private readonly IPaisesService _service;
        private readonly IApoderadosService _apoderadosService;

   

        public PaisesController(IPaisesService service, IApoderadosService apoderadosService)
        {
            _service = service;
            _apoderadosService = apoderadosService;
        }
        public async Task<IActionResult> Index()
        {   
            var allPaises= await _service.GetAllAsync();
            var paisMenus = await _service.GetNuevoMenusValores();
            ViewBag.Apoderados = new SelectList(paisMenus.Apoderados, "id", "email");
            return View(allPaises);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var detallePais = await _service.GetPaisByIdAsync(id);
            if (detallePais == null) return View("NotFound");
            return View(detallePais);
        }
        //GET: producers/create
        public async Task<IActionResult> Create()
        {
            var paisMenu = await _service.GetNuevoMenusValores();
            var PaisesSelectList = paisMenu.Apoderados.Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.email });
            ViewBag.Apoderados = PaisesSelectList;
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create( PaisVM dato)
        {
            if (!ModelState.IsValid)
            {
                var paisMenu = await _service.GetNuevoMenusValores();
                var PaisesSelectList = paisMenu.Apoderados.Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.email });
                ViewBag.Apoderados = PaisesSelectList;
                return View(dato);
            }
            await _service.AddPaisAsync(dato);

            return RedirectToAction(nameof(Index));
        }

        //GET: producers/edit/1
        [AllowAnonymous]
        public async Task<IActionResult> Edit(int id)
        {
            var detallePais = await _service.GetPaisByIdAsync(id);
            if (detallePais == null) return View("NotFound");

            var response = new PaisVM()
            {
                id = detallePais.Id,
                pais = detallePais.pais,
                region = detallePais.region,
                direccion = detallePais.direccion,
                logo = detallePais.logo,
                idApoderado = detallePais.idApoderado,
                
               
            };
            Console.Write("cuando carga la vista");
            Console.Write("el id es " + id + " response.Id es :" + response.id);
            var paisMenu = await _service.GetNuevoMenusValores();
            var PaisesSelectList = paisMenu.Apoderados.Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.email });
            ViewBag.Apoderados = PaisesSelectList;

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,PaisVM dato)
        {
            Console.Write("el pais.pais es " + dato.pais + " pais.logo es :" + dato.logo);
            Console.Write("el id es " + id + " pais.Id es :" + dato.id);
            if (id != dato.id) return View("NotFound");
            if (!ModelState.IsValid) {
                var paisMenu = await _service.GetNuevoMenusValores();
                var PaisesSelectList = paisMenu.Apoderados.Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.email });
                ViewBag.Apoderados = PaisesSelectList;
                return View(dato);
            } 

      
                await _service.UpdatePaisAsync(dato);
                return RedirectToAction(nameof(Index));
            
              }

        //GET: producers/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var detallePais = await _service.GetPaisByIdAsync(id);
            if (detallePais == null) return View("NotFound");
            return View(detallePais);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detallePais = await _service.GetPaisByIdAsync(id);
            if (detallePais == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
