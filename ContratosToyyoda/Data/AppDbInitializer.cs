﻿using ContratosToyyoda.Models;

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
                            
                              nombreUsuario= "RP09041",
                              nombre=   "Harrisson" ,
                              apellido=  "Rivera" ,
                              contrasena=  "RP09041",
                   
                        },
                      new Usuario()
                        {
                             
                              nombreUsuario= "AA19103",
                              nombre=  "Claudia"   ,
                              apellido=  "Avila"  ,
                              contrasena=  "AA19103",

                        },
                        new Usuario()
                        {
                             
                              nombreUsuario= "RD18025",
                              nombre=  "Marvin"  ,
                              apellido=   "Rodríguez" ,
                              contrasena= "RD18025",

                        },
                 
                    });
                    context.SaveChanges();

                }
                ///pises
                ///
                if (!context.Paises.Any())
                {
                    context.Paises.AddRange(new List<Pais>()
                    {

                       new Pais()
                        {
                           

                           pais ="El Salvador",
                           region ="Centro America",
                           direccion ="Av. Narciso Monterrey 14A, Zacatecoluca, La Paz, El salvador",

                          logoUrl ="https://drive.google.com/file/d/1MbdJrdfWXCmviCNCHwR5isD5SjqMgOnz/view?usp=sharing"
                       },

                    new Pais()
                        {
                          

                           pais ="Guatemala",
                           region ="Centro America",
                          direccion ="Av. Las Americas, Quezaltenango, Guatemala",

                          logoUrl ="https://drive.google.com/file/d/197BcS_9G3a-iFmFMe9QoQUl7sD9znMK4/view?usp=share_link"
                          },

                    new Pais()
                        {
                           
                           pais ="Honduras",
                           region ="Centro America",
                           direccion ="Avenido Cervantes Number 1515, Tegucigalpa, Honduras",

                          logoUrl ="https://drive.google.com/file/d/1vGVJ-wpgpANN5mQNP4l8xZdkdCyyP_lU/view?usp=share_link",

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

                         sueldo =360.0,

                         tipoContrato=TipoContrato.permanente,

                         fechaIngreso=DateTime.Now.AddDays(-10),
                         fechaEmision =DateTime.Now.AddDays(-10),
                          idUser=1,
                          idPais=2
                      },
                
                        new Contrato()
                     {
                           
                          nombre="Segundo contrato",

                         apellido="segundo contrato",

                         sueldo =360.0,

                         tipoContrato=TipoContrato.permanente,

                         fechaIngreso=DateTime.Now.AddDays(-10),
                          fechaEmision =DateTime.Now.AddDays(-10),

                          idUser=2,
                          idPais=2



                      },

                        new Contrato()
                     {
                         
                          nombre="Segundo contrato",

                         apellido="segundo contrato",

                         sueldo =5000.0,

                         tipoContrato=TipoContrato.temporal,

                         fechaIngreso=DateTime.Now.AddDays(-10),
                          fechaEmision =DateTime.Now.AddDays(-10),

                          idUser=3,
                          idPais=3
                      }

                     });
                    context.SaveChanges();

                }
            }
        }
    }
}