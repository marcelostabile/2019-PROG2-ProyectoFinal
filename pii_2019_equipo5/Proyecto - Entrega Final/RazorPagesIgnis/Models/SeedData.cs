using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using RazorPagesIgnis.Models;

namespace RazorPagesIgnis
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
                SeedTecnicoSolicitudes(context);
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
                    Nombre = "Marcelo",
                    Correo = "marce@correo.com", 
                    Contrasena = "********"
                },

                new Administrador 
                {
                    Nombre = "Alvaro",
                    Correo = "elalvaro@correo.com", 
                    Contrasena = "********"
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
                    Nombre = "Micaela",
                    Correo = "mica@correo.com", 
                    Contrasena = "********"
                },

                new Cliente 
                {
                    Nombre = "Roberto",
                    Correo = "roberto@correo.com", 
                    Contrasena = "********"
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
                    Nombre = "Marcelo",
                    Correo = "marce@correo.com", 
                    Contrasena = "********", 
                    Edad = 40,
                    Presentacion = "Hola!", 
                    Nivel_experiencia = "Básico"
                },

                new Tecnico 
                {
                    Nombre = "Laura",
                    Correo = "laura@correo.com", 
                    Contrasena = "********", 
                    Edad = 25,
                    Presentacion = "Buen día!", 
                    Nivel_experiencia = "Avanzado"
                },

                new Tecnico 
                {
                    Nombre = "Diego",
                    Correo = "eldiego@correo.com", 
                    Contrasena = "********", 
                    Edad = 22,
                    Presentacion = "Buenas tardes!", 
                    Nivel_experiencia = "Básico"
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
                    ModoDeContrato = 1, 
                    RolRequerido = "Camarografo", 
                    HorasContratadas = 8, 
                    NivelExperiencia = "Básico", 
                    Observaciones = "obs..."
                },

                new Solicitud 
                {
                    ModoDeContrato = 2, 
                    RolRequerido = "Luces", 
                    HorasContratadas = 10, 
                    NivelExperiencia = "Avanzado", 
                    Observaciones = "no."
                },

                new Solicitud 
                {
                    ModoDeContrato = 1, 
                    RolRequerido = "Director", 
                    HorasContratadas = 15, 
                    NivelExperiencia = "Básico", 
                    Observaciones = "no."
                }
            );
            context.SaveChanges();
        }

        /// <summary>
        /// Seeding TecnicoSolicitud.
        /// </summary>
        private static void SeedTecnicoSolicitudes(IgnisContext context)
        {
            if (context.TecnicoSolicitudes.Any()) 
            {
                return;
            }

            var tecnicoSolictudes = new TecnicoSolicitud[]
            {
                new TecnicoSolicitud 
                {
                    tecnicoID = context.Tecnicos.Single(t => t.Nombre == "Marcelo").ID, 
                    solicitudID = context.Solicitudes.Single(s => s.ID == 1).ID 
                },

                new TecnicoSolicitud 
                {
                    tecnicoID = context.Tecnicos.Single(t => t.Nombre == "Marcelo").ID, 
                    solicitudID = context.Solicitudes.Single(s => s.ID == 3).ID 
                },

                new TecnicoSolicitud 
                {
                    tecnicoID = context.Tecnicos.Single(t => t.Nombre == "Laura").ID, 
                    solicitudID = context.Solicitudes.Single(s => s.ID == 2).ID 
                }
            };

            foreach (TecnicoSolicitud ts in tecnicoSolictudes)
            {
                context.TecnicoSolicitudes.Add(ts);
            }

            context.SaveChanges();
        }

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
                    Nombre = "Hulk Aplasta!!!", 
                    Descripcion = "El héroe verde regresa... más enojado que nunca!"
                },

                new Proyecto 
                {
                    Nombre = "Docu-mental",
                    Descripcion = "Investigación." 
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
                    Nombre = "Cámara", 
                    Descripcion = "."
                },

                new Rol 
                {
                    Nombre = "Luces", 
                    Descripcion = ".."
                },

                new Rol 
                {
                    Nombre = "Director",
                    Descripcion = "..." 
                }
            );
            context.SaveChanges();
        }
    }
}
