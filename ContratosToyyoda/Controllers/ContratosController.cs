using ContratosToyyoda.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContratosToyyoda.Controllers
{
    public class ContratosController : Controller
    {
        private readonly AppDbContext _context;

        public ContratosController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allContratos = await _context.Contratos.ToListAsync();
            return View(allContratos);
        }
    }
}
