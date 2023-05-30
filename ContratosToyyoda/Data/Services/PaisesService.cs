using ContratosToyyoda.Data.Base;
using ContratosToyyoda.Data.ViewModels;
using ContratosToyyoda.Models;
using Microsoft.EntityFrameworkCore;

namespace ContratosToyyoda.Data.Services
{
    public class PaisesService: EntityBaseRepository<Pais>, IPaisesService
    {
        private readonly AppDbContext _context;
        public PaisesService(AppDbContext context):base (context)
        {
            _context = context;
        }

        public async Task<PaisMenuVM> GetNuevoMenusValores()
        {
            var response = new PaisMenuVM()
            {
                Apoderados = await _context.Apoderados.OrderBy(p => p.email).ToListAsync(),                
            };

            return response;
        }


        public async Task UpdatePaisAsync(PaisVM dato)
        {
            var dbPais = await _context.Paises.FirstOrDefaultAsync(n => n.Id == dato.id);

            if (dbPais != null)
            {

                dbPais.pais = dato.pais;
                dbPais.region = dato.region;
                dbPais.direccion = dato.direccion;
                dbPais.logo = dato.logo;
                dbPais.idApoderado = dato.idApoderado;
                
                await _context.SaveChangesAsync();
            };
        }


        public async Task AddPaisAsync(PaisVM dato)
        {
            var nuevoPais = new Pais()
            {
                pais = dato.pais,
                region = dato.region,
                direccion = dato.direccion,
                logo = dato.logo,
                idApoderado = dato.idApoderado,
                
            };
            await _context.Paises.AddAsync(nuevoPais);
            await _context.SaveChangesAsync();
        }

        public async Task<Pais> GetPaisByIdAsync(int id)
        {
            var Paisdetalles = _context.Paises.Include(u => u.apoderado).FirstOrDefaultAsync(n => n.Id == id);
            return await Paisdetalles;
        }
    }
}
