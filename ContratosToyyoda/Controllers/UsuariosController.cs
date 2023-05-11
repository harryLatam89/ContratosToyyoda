using ContratosToyyoda.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContratosToyyoda.Controllers
{
    public class UsuariosController : Controller
    {

        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {   
            var allUsuarios= await _context.Usuarios.ToListAsync();
            return View();
        }
    }
}
