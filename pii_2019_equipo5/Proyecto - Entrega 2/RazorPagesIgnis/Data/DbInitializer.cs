using System;
using System.Linq;
using RazorPagesIgnis.Models;

namespace RazorPagesIgnis
{
    public static class DbInitializer
    {
        public static void Initialize(RazorPagesIgnisContext context)
        {
            // context.Database.EnsureCreated();

            // Administrador.
            if (!context.Administrador.Any()) 
            {
                var admins = new Administrador[]
                {
                new Administrador("Marcelo", "marce@correo.com", "********"), 
                new Administrador("Alvaro", "elalvaro@correo.com", "********")
                };

                foreach (Administrador itemA in admins)
                {
                    context.Administrador.Add(itemA);
                }
                context.SaveChanges();
            }

            // Clientes.
            if (!context.Cliente.Any()) 
            {
                var clientes = new Cliente[]
                {
                new Cliente("Micaela", "mica@correo.com", "********"), 
                new Cliente("Roberto", "roberto@correo.com", "********")
                };

                foreach (Cliente item in clientes)
                {
                    context.Cliente.Add(item);
                }
                context.SaveChanges();
            }

            // Técnicos.
            if (!context.Tecnico.Any()) 
            {
                var tecnicos = new Tecnico[]
                {
                new Tecnico ("Marcelo", "marce@correo.com", "********", 40, "Hola!", "Básico"),
                new Tecnico ("Laura", "laura@correo.com", "********", 25, "Buen día!", "Avanzado"),
                new Tecnico ("Diego", "eldiego@correo.com", "********", 22, "Buenas tardes!", "Básico")
                };

                foreach (Tecnico itemT in tecnicos)
                {
                    context.Tecnico.Add(itemT);
                }
                context.SaveChanges();
            } 

            // Solicitudes.
            if (!context.Solicitud.Any()) 
            {
                var solicitudes = new Solicitud[]
                {
                new Solicitud(1, "Camara", 8, "Básico", "obs..."), 
                new Solicitud(2, "Luces", 10, "Avanzado", "no"), 
                new Solicitud(1, "Director", 15, "Avanzado", "no")
                };

                foreach (Solicitud itemS in solicitudes)
                {
                    context.Solicitud.Add(itemS);
                }
                context.SaveChanges();
            } 

            // TecnicoSolicitud
            if (!context.TecnicoSolicitud.Any()) 
            {
                var tecnSolicitud = new TecnicoSolicitud[]
                {
                new TecnicoSolicitud(1, 1),
                new TecnicoSolicitud(1, 2),
                new TecnicoSolicitud(2, 3)
                };

                foreach (TecnicoSolicitud itemTS in tecnSolicitud)
                {
                    context.TecnicoSolicitud.Add(itemTS);
                }
                context.SaveChanges();
            } 

            // Proyecto.
            if (!context.Proyecto.Any()) 
            {
                var proyecto = new Proyecto[]
                {
                new Proyecto("Hulk Aplasta!!!", "El héroe verde regresa... más enojado!"),
                new Proyecto("Docu-mental", "Investigación.")
                };

                foreach (Proyecto item in proyecto)
                {
                    context.Proyecto.Add(item);
                }
                context.SaveChanges();
            } 

            // Rol.
            if (!context.Rol.Any()) 
            {
                var rol = new Rol[]
                {
                new Rol("Cámara", "."),
                new Rol("Director", ". ."),
                new Rol("Luces", ". . .")
                };

                foreach (Rol item in rol)
                {
                    context.Rol.Add(item);
                }
                context.SaveChanges();
            } 

        }
    }
}