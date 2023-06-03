using Azure.Messaging;
using ContratosToyyoda.Data;
using ContratosToyyoda.Data.Services;
using ContratosToyyoda.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;

namespace ContratosToyyoda.Controllers
{
    
    public class UsuariosController : Controller
    {

        private readonly IUsuariosService _service;

        public UsuariosController(IUsuariosService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {   
            var allUsuarios=await  _service.GetAllAsync();
            return View(allUsuarios);
        }

        // metodo get Usuarios / crear
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("nombre,apellido,email,contrasena,rol")]Usuario dato)
        {
          
            if (!ModelState.IsValid)
            {
                foreach (var key in ModelState.Keys)
                {
                    var errors = ModelState[key].Errors;

                    foreach (var error in errors)
                    {
                        var errorMessage = error.ErrorMessage;
                        // Manejar el mensaje de error
                        Console.Out.WriteLine(errorMessage);
                    }
                }
                
                return View(dato);
            }


            await _service.AddAsync(dato);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var detallesUsuario = await _service.GetByIdAsync(id);

            if (detallesUsuario == null) return View("NotFound");
            return View(detallesUsuario);
        }

        //Get: Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var detallesUsuario = await _service.GetByIdAsync(id);
            if (detallesUsuario == null) return View("NotFound");
            return View(detallesUsuario);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nombre,apellido,email,contrasena,rol")] Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }
            await _service.UpdateAsync(usuario.Id, usuario);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var detallesUsuario = await _service.GetByIdAsync(id);
            if (detallesUsuario == null) return View("NotFound");
            return View(detallesUsuario);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detallesUsuario = await _service.GetByIdAsync(id);
            if (detallesUsuario == null) return View("NotFound");

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
