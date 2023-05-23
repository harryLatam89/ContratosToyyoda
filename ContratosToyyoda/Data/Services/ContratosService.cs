using ContratosToyyoda.Data.Base;
using ContratosToyyoda.Data.ViewModels;
using ContratosToyyoda.Models;
using Microsoft.EntityFrameworkCore;

namespace ContratosToyyoda.Data.Services
{
    public class ContratosService:EntityBaseRepository<Contrato>,IContratosService
    {
        private readonly AppDbContext _context;
        public ContratosService(AppDbContext context):base(context)
        {
            _context = context;
        }

        public async Task AddNuevoContratoAsync(NuevoContratoVM dato)
        {
            var nuevoContrato = new Contrato()
            {
                nombre = dato.nombre,
                apellido = dato.apellido,
                tipoContrato = dato.tipoContrato,
                sueldo = dato.sueldo,
                idPais = dato.idPais,
                idUser = dato.idUser,
                fechaIngreso = dato.fechaIngreso,
                fechaEmision = dato.fechaEmision,
                 email = dato.email
        };
            await _context.Contratos.AddAsync(nuevoContrato);
            await _context.SaveChangesAsync();
            //agregar el 
        }

        public async Task<Contrato> GetContratoByIdAsync(int id)
        {
            var contratoDetails = _context.Contratos.Include(u => u.usuario).Include(p => p.pais).FirstOrDefaultAsync(n => n.Id == id);
            return await contratoDetails;
        }

        public async Task<NuevoContratoMenusVM> GetNuevoMenusValores()
        {
            var response = new NuevoContratoMenusVM()
            {
                Paises = await _context.Paises.OrderBy(p => p.pais).ToListAsync(),
                Usuarios = await _context.Usuarios.OrderBy(p => p.email).ToListAsync(),
            };

            return response;
        }

        public async Task UpdateContratoAsync(NuevoContratoVM dato)
        {
            var dbContrato = await _context.Contratos.FirstOrDefaultAsync(n => n.Id == dato.id);

            if (dbContrato != null)
            {

                dbContrato.nombre = dato.nombre;
                    dbContrato.apellido = dato.apellido;
                dbContrato.tipoContrato = dato.tipoContrato;
                dbContrato.sueldo = dato.sueldo;
                dbContrato.idPais = dato.idPais;
                dbContrato.idUser = dato.idUser;
                dbContrato.fechaIngreso = dato.fechaIngreso;
                dbContrato.fechaEmision = dato.fechaEmision;
                dbContrato.email=dato.email;
                
                await _context.SaveChangesAsync();
            };
               
            


        }
    }
}
