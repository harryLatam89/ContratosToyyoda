using ContratosToyyoda.Data.Services;
using ContratosToyyoda.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContratosToyyoda.Controllers
{
    public class ApoderadosController : Controller
    {

        private readonly IApoderadosService _service;

       
        public ApoderadosController(IApoderadosService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allApoderados = await _service.GetAllAsync();
            return View(allApoderados);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var apoderado = await _service.GetByIdAsync(id);
         
            if (apoderado == null) return View("NotFound");
            return View(apoderado);
        }

        //GET: producers/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Apoderado dato)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(dato);
            }
            await _service.AddAsync(dato);
            return RedirectToAction(nameof(Index));
        }

        //GET: producers/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var apoderado = await _service.GetByIdAsync(id);
            if (apoderado == null) return View("NotFound");
            return View(apoderado);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nombre,apellido,email,sexo,estadoFamiliar,profesion,domicilio,nacionalidad,TipoDoc,numDocId,fechaNacimiento")] Apoderado apoderado)
        {
            if (!ModelState.IsValid) return View(apoderado);
            await _service.UpdateAsync(id, apoderado);
            return RedirectToAction(nameof(Index));

        }
        //GET: producers/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var apoderado = await _service.GetByIdAsync(id);
            if (apoderado == null) return View("NotFound");
            return View(apoderado);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apoderado = await _service.GetByIdAsync(id);
            if (apoderado == null) return View("NotFound");

            try
            {
                await _service.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex) 
            {
               
                TempData["Error"] = "No es posible eliminar el registro debido a las dependencias existentes.";
                return RedirectToAction(nameof(Delete), new { id });
            }
            
        }
    }
}
