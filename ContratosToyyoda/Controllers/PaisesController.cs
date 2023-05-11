using ContratosToyyoda.Data;
using Microsoft.AspNetCore.Mvc;

namespace ContratosToyyoda.Controllers
{
    public class PaisesController : Controller
    {
        private readonly AppDbContext _context;

        public PaisesController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {   
            var allPaises= _context.Paises.ToList();
            return View();
        }


    }
}
