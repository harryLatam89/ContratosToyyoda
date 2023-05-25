using ContratosToyyoda.Data;
using ContratosToyyoda.Data.Services;
using ContratosToyyoda.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ContratosToyyoda.Data.ViewModels;
using Microsoft.AspNetCore.Hosting;

namespace ContratosToyyoda.Controllers
{
    public class PaisesController : Controller
    {
        private readonly IPaisesService _service;
    
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PaisesController(IPaisesService service, IWebHostEnvironment webHostEnvironment)
        {
            _service = service;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {   
            var allPaises= await _service.GetAllAsync();
            return View(allPaises);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var detallePais = await _service.GetByIdAsync(id);
            if (detallePais == null) return View("NotFound");
            return View(detallePais);
        }
        //GET: producers/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("pais,region,direccion,logo")] Pais dato)
        {
            if (!ModelState.IsValid)
            {
                return View(dato);
            }
            await _service.AddAsync(dato);

            return RedirectToAction(nameof(Index));
        }

        //GET: producers/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var detallePais = await _service.GetByIdAsync(id);
            if (detallePais == null) return View("NotFound");
            return View(detallePais);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,pais,region,direccion,logoUrl")] Pais dato)
        {
            if (!ModelState.IsValid) return View(dato);

      
                await _service.UpdateAsync(id, dato);
                return RedirectToAction(nameof(Index));
            
              }

        //GET: producers/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var detallePais = await _service.GetByIdAsync(id);
            if (detallePais == null) return View("NotFound");
            return View(detallePais);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detallePais = await _service.GetByIdAsync(id);
            if (detallePais == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
