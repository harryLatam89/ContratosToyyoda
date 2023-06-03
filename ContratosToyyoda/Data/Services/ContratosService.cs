using Azure.Core;
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
                 email = dato.email,
                sexo=dato.sexo,
                estadoFamiliar=dato.estadoFamiliar,
                profesion=dato.profesion,
                domicilio= dato.domicilio,
                nacionalidad= dato.nacionalidad,
                TipoDoc= dato.TipoDoc,
                numDocId= dato.numDocId,
                cargo= dato.cargo,
                fechaNacimiento=dato.fechaNacimiento,
                
            };
            await _context.Contratos.AddAsync(nuevoContrato);
            await _context.SaveChangesAsync();
     


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
                dbContrato.sexo = dato.sexo;
                dbContrato.estadoFamiliar = dato.estadoFamiliar;
                dbContrato.profesion = dato.profesion;
                dbContrato.domicilio = dato.domicilio;
                dbContrato.nacionalidad = dato.nacionalidad;
                dbContrato.TipoDoc = dato.TipoDoc;
                dbContrato.numDocId = dato.numDocId;
                dbContrato.cargo= dato.cargo;
                dbContrato.fechaNacimiento = dato.fechaNacimiento;
                dbContrato.inactivo = dato.inactivo;
                dbContrato.fechaFin = dato.fechaFin;

                await _context.SaveChangesAsync();
            };
               
            


        }

        public async Task<Contrato> GetContratoByEmailAsync(string email)
        {
            // Realizar la consulta a la base de datos para obtener el contrato por email
            var contrato =  _context.Contratos.FirstOrDefaultAsync(c => c.email == email);

            return await contrato;
        }

        public async Task<List<Contrato>> GetContratosActivosAsync()
        {
            var contratosActivos = await _context.Contratos.Where(c => c.inactivo == false).ToListAsync();
            return contratosActivos;
        }

        public async Task<List<Contrato>> GetContratosInactivosAsync()
        {
            var contratosActivos = await _context.Contratos.Where(c => c.inactivo ).ToListAsync();
            return contratosActivos;
        }
    }
}
