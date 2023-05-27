using ContratosToyyoda.Models;
using System.ComponentModel.DataAnnotations;



namespace ContratosToyyoda.Data
{
    public class AppDbInitializer
    {
        public static void Seed (IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope= applicationBuilder.ApplicationServices.CreateScope())
            {
                var context= serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                //
                //users
                if (!context.Usuarios.Any())
                {
                    context.Usuarios.AddRange(new List<Usuario>()
                    {
                        new Usuario()
                        {

                              email= "harrisson.rivera@toyyoda.com",
                              nombre=   "Harrisson" ,
                              apellido=  "Rivera" ,
                              contrasena=  "RP09041",
                               rol="user"
                        },
                      new Usuario()
                        {
                              email= "claudia.avila@toyyoda.com",
                             nombre=  "Claudia"   ,
                              apellido=  "Avila"  ,
                              contrasena=  "AA19103",
                              rol="admin"
                        },
                        new Usuario()
                        {
                               email="marvin.rodriguez@toyyoda.com",
                             nombre=  "Marvin"  ,
                              apellido=   "Rodríguez" ,
                              contrasena= "RD18025",
                               rol="user"
                        },
                 
                    });
                    context.SaveChanges();

                }
           
                if (!context.Paises.Any())
                {
                    context.Paises.AddRange(new List<Pais>()
                    {

                       new Pais()
                        {
                           

                           pais ="El Salvador",
                           region ="Centro America",
                           direccion ="Av. Narciso Monterrey 14A, Zacatecoluca, La Paz, El salvador",

                          logo ="https://cdn.pixabay.com/photo/2015/08/06/17/40/el-salvador-878218_640.png"
                       },

                    new Pais()
                        {
                          

                           pais ="Guatemala",
                           region ="Centro America",
                          direccion ="Av. Las Americas, Quezaltenango, Guatemala",

                          logo ="https://cdn.pixabay.com/photo/2015/08/05/07/49/guatemala-875735_640.png"
                          },

                    new Pais()
                        {
                           
                           pais ="Honduras",
                           region ="Centro America",
                           direccion ="Avenido Cervantes Number 1515, Tegucigalpa, Honduras",

                          logo ="https://cdn.pixabay.com/photo/2015/08/16/06/26/honduras-890666_640.png",

                        }
                    });
                    context.SaveChanges();
                }
                  ////contratos
                   if (!context.Contratos.Any())
                   {
                       context.Contratos.AddRange(new List<Contrato>()
                       {


                       new Contrato()
                        {

                            nombre="primer contrato",

                            apellido="primer contrato",

                            email= "primer.contrato@toyyoda.com",

                            sueldo =360.0,

                            tipoContrato=TipoContrato.permanente,

                            fechaIngreso=DateTime.Now.AddDays(-10),
                            fechaEmision =DateTime.Now.AddDays(-5),
                             idUser=1,
                             idPais=2
                         },

                           new Contrato()
                        {

                             nombre="Segundo contrato",

                            apellido="segundo contrato",

                              email= "segundo.contrato@toyyoda.com",

                            sueldo =360.0,

                            tipoContrato=TipoContrato.permanente,

                            fechaIngreso=DateTime.Now.AddDays(-10),
                             fechaEmision =DateTime.Now.AddDays(-10),

                             idUser=1,
                             idPais=2



                         },

                           new Contrato()
                        {

                             nombre="Tercer contrato",

                            apellido="Tercer contrato",

                                 email= "Tercer.contrato@toyyoda.com",

                            sueldo =5000.0,

                            tipoContrato=TipoContrato.temporal,

                            fechaIngreso=DateTime.Now.AddDays(-10),
                             fechaEmision =DateTime.Now.AddDays(-10),

                             idUser=1,
                             idPais=3
                         }

                        });
                       context.SaveChanges();

                   }

                   
            }
        }
    }
}
