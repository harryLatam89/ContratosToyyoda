using ContratosToyyoda.Data;
using ContratosToyyoda.Data.Static;
using ContratosToyyoda.Data.ViewModels;
using ContratosToyyoda.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.Identity.Client;

namespace ContratosToyyoda.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UsuarioAplicacion> _userManager;
        private readonly SignInManager<UsuarioAplicacion> _signInManager;
        private readonly AppDbContext _context;


        public async Task<IActionResult> Usuarios()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }
        public AccountController(UserManager<UsuarioAplicacion> userManager, SignInManager<UsuarioAplicacion> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Login() => View(new LoginVM());

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVm)
        {
            if (!ModelState.IsValid) return View(loginVm);

            

                var user = await _userManager.FindByEmailAsync(loginVm.EmailAddress);
            if (user != null) {
                      
                        var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVm.Password);
                        if (passwordCheck)
                        {
                            var result = await _signInManager.PasswordSignInAsync(user, loginVm.Password, false, false);
                            if (result.Succeeded)

                            {
                               Console.WriteLine(user.Id.ToString());
                                return RedirectToAction("Index", "Home");
                            }
                        }

                TempData["Error"] = "Credenciales incorrectas";
                return View(loginVm);
            }


            TempData["Error"] = "Credenciales incorrectas";
            return View(loginVm);   
        }


        public IActionResult Registrar() => View(new RegistrarVM());

        [HttpPost]
        public async Task<IActionResult> Registrar(RegistrarVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "este correo ya esta en uso";
                return View(registerVM);
            }

            var newUser = new UsuarioAplicacion()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress,
                EmailConfirmed = true

            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            return RedirectToAction(nameof(RegistroCompletado));
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        public IActionResult AccessoDenegado(string ReturnUrl)
        {
            return View();
        }

        public IActionResult RegistroCompletado()
        {
            return View();
        }



    }
}
