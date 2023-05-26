using Microsoft.AspNetCore.Mvc;
using ContratosToyyoda.Data.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ContratosToyyoda.Models;
using ContratosToyyoda.Data;
using Microsoft.EntityFrameworkCore;
using ContratosToyyoda.Data.Services;

namespace ContratosToyyoda.Controllers
{
    public class AccessController : Controller
    {
      
        private readonly IUsuariosService _service;

        public AccessController(IUsuariosService service)
        {
            _service = service;
        }
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(VMLogin modelLogin)
        {
            // Buscar el usuario en la base de datos por el correo electrónico
            var allUsuarios = await _service.GetAllAsync();

            var passwordDB = string.Empty; // Variable para almacenar la contraseña
            var nombreUsuario= string.Empty;
            var rolUsuario= string.Empty;
            foreach (var usuario in allUsuarios)
            {
                if (usuario.email == modelLogin.Email)
                {
                    passwordDB = usuario.contrasena;
                    nombreUsuario= usuario.nombre;
                    rolUsuario=usuario.rol;
                    break; // Se encontró el usuario, se sale del bucle
                }
            }
            Console.WriteLine("***************** estoy aca la contrasena es ");
            if (  passwordDB == modelLogin.PassWord)
            {
                List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, modelLogin.Email),
                     new Claim(ClaimTypes.Name,nombreUsuario),
               
                    new Claim("OtherProperties","Example Role")
                };

                Console.WriteLine("***************** estoy aca la el roll es rolUsuario es " + rolUsuario);
                if (rolUsuario == "admin")
              {
                    claims.Add(new Claim(ClaimTypes.Role, "admin"));
                    Console.WriteLine("***************** estoy aca agregadno rol admin" );
                }
               else
                {
                    claims.Add(new Claim(ClaimTypes.Role, "user"));
               }

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = modelLogin.KeepLoggedIn
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);

                return RedirectToAction("Index", "Home");
            }

            ViewData["ValidateMessage"] = "CREDENCIALES INCORRECTAS";
            return View();
        }

    }
}

