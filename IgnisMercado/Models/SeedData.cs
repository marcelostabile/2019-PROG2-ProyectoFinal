using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using IgnisMercado.Models; 

namespace IgnisMercado 
{
    /// <summary>
    /// Esta clase nos permite inicializar la base de datos luego de creada, 
    /// agregando valores por defecto. En todos los casos solo se agregan valores 
    /// si no hay registros previos en la tabla.
    /// </summary>
    public static class SeedData 
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new IgnisContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<IgnisContext>>()))
            {
                SeedAdministradores(context);
                SeedClientes(context);
                SeedTecnicos(context);
                SeedSolicitudes(context);
                SeedProyectos(context);
                SeedRoles(context);
            }
        }

        /// <summary>
        /// Seeding Administrador.
        /// </summary>
        private static void SeedAdministradores(IgnisContext context)
        {
            if (context.Administradores.Any()) 
            {
                return;
            }

            context.Administradores.AddRange(
                new Administrador 
                {
                    nombre = "Marcelo",
                    correo = "marce@correo.com", 
                    contrasena = "********"
                },

                new Administrador 
                {
                    nombre = "Alvaro",
                    correo = "elalvaro@correo.com", 
                    contrasena = "********"
                }
            );
            context.SaveChanges();
        }

        /// <summary>
        /// Seeding Cliente.
        /// </summary>
        private static void SeedClientes(IgnisContext context)
        {
            if (context.Clientes.Any()) 
            {
                return;
            }

            context.Clientes.AddRange(
                new Cliente 
                {
                    nombre = "Micaela",
                    correo = "mica@correo.com", 
                    contrasena = "********"
                },

                new Cliente 
                {
                    nombre = "Roberto",
                    correo = "roberto@correo.com", 
                    contrasena = "********"
                }
            );
            context.SaveChanges();
        }

        /// <summary>
        /// Seeding Técnico.
        /// </summary>
        private static void SeedTecnicos(IgnisContext context)
        {
            if (context.Tecnicos.Any()) 
            {
                return;
            }

            context.Tecnicos.AddRange(
                new Tecnico 
                {
                    nombre = "Marcelo",
                    correo = "marce@correo.com", 
                    contrasena = "********", 
                    edad = 40,
                    presentacion = "Hola!", 
                    nivelExperiencia = "Básico"
                },

                new Tecnico 
                {
                    nombre = "Laura",
                    correo = "laura@correo.com", 
                    contrasena = "********", 
                    edad = 25,
                    presentacion = "Buen día!", 
                    nivelExperiencia = "Avanzado"
                },

                new Tecnico 
                {
                    nombre = "Diego",
                    correo = "eldiego@correo.com", 
                    contrasena = "********", 
                    edad = 22,
                    presentacion = "Buenas tardes!", 
                    nivelExperiencia = "Básico"
                }
            );
            context.SaveChanges();
        }

        /// <summary>
        /// Seeding Solicitud.
        /// </summary>
        private static void SeedSolicitudes(IgnisContext context)
        {
            if (context.Solicitudes.Any()) 
            {
                return;
            }

            context.Solicitudes.AddRange(
                new Solicitud 
                {
                    modoDeContrato = 1, 
                    rolRequerido = "Camarografo", 
                    horasContratadas = 8, 
                    nivelExperiencia = "Básico", 
                    observaciones = "obs..."
                },

                new Solicitud 
                {
                    modoDeContrato = 2, 
                    rolRequerido = "Luces", 
                    horasContratadas = 10, 
                    nivelExperiencia = "Avanzado", 
                    observaciones = "no."
                },

                new Solicitud 
                {
                    modoDeContrato = 1, 
                    rolRequerido = "Director", 
                    horasContratadas = 15, 
                    nivelExperiencia = "Básico", 
                    observaciones = "no."
                }
            );
            context.SaveChanges();
        }

        // /// <summary>
        // /// Seeding TecnicoSolicitud.
        // /// </summary>
        // private static void SeedTecnicoSolicitudes(IgnisContext context)
        // {
        //     if (context.tecnicoSolicitudes.Any()) 
        //     {
        //         return;
        //     }

        //     var tecnicoSolictudes = new TecnicoSolicitud[]
        //     {
        //         new TecnicoSolicitud 
        //         {
        //             tecnicoID = context.Tecnicos.Single(t => t.Nombre == "Marcelo").ID, 
        //             solicitudID = context.Solicitudes.Single(s => s.ID == 1).ID 
        //         },

        //         new TecnicoSolicitud 
        //         {
        //             tecnicoID = context.Tecnicos.Single(t => t.Nombre == "Marcelo").ID, 
        //             solicitudID = context.Solicitudes.Single(s => s.ID == 3).ID 
        //         },

        //         new TecnicoSolicitud 
        //         {
        //             tecnicoID = context.Tecnicos.Single(t => t.Nombre == "Laura").ID, 
        //             solicitudID = context.Solicitudes.Single(s => s.ID == 2).ID 
        //         }
        //     };

        //     foreach (TecnicoSolicitud ts in tecnicoSolictudes)
        //     {
        //         context.TecnicoSolicitudes.Add(ts);
        //     }

        //     context.SaveChanges();
        // }

        /// <summary>
        /// Seeding Proyecto.
        /// </summary>
        private static void SeedProyectos(IgnisContext context)
        {
            if (context.Proyectos.Any()) 
            {
                return;
            }

            context.Proyectos.AddRange(
                new Proyecto 
                {
                    nombre = "Hulk Aplasta!!!", 
                    descripcion = "El héroe verde regresa... más enojado que nunca!"
                },

                new Proyecto 
                {
                    nombre = "Docu-mental",
                    descripcion = "Investigación." 
                }
            );
            context.SaveChanges();
        }

        /// <summary>
        /// Seeding Rol.
        /// </summary>
        private static void SeedRoles(IgnisContext context)
        {
            if (context.Roles.Any()) 
            {
                return;
            }

            context.Roles.AddRange(
                new Rol 
                {
                    nombre = "Cámara", 
                    descripcion = "."
                },

                new Rol 
                {
                    nombre = "Luces", 
                    descripcion = ".."
                },

                new Rol 
                {
                    nombre = "Director",
                    descripcion = "..." 
                }
            );
            context.SaveChanges();
        }
    }
}
