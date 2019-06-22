// using System;
// using System.Linq;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;

// namespace IgnisMercado.Models 
// {
//     /// <summary>
//     /// Esta clase nos permite inicializar la base de datos luego de creada, 
//     /// agregando valores por defecto. En todos los casos solo se agregan valores 
//     /// si no hay registros previos en la tabla.
//     /// </summary>
//     public static class SeedData
//     {
//         public static void Initialize(IServiceProvider serviceProvider)
//         {
//             using (var context = new ApplicationContext(
//                 serviceProvider.GetRequiredService<
//                     DbContextOptions<ApplicationContext>>()))
//             {
//                 SeedAdministradores(context);
//                 SeedClientes(context);
//                 SeedTecnicos(context);
//                 SeedProyectos(context);
//                 SeedSolicitudes(context);
//                 SeedRoles(context);
//             }
//         }

//         /// <summary>
//         /// Seeding Administrador.
//         /// </summary>
//         private static void SeedAdministradores(ApplicationContext context)
//         {
//             if (context.Administradores.Any()) 
//             {
//                 return;
//             }

//             context.Administradores.AddRange(
//                 new Administrador 
//                 {
//                     nombre = "Marcelo",
//                     correo = "marce@correo.com", 
//                     contrasena = "********"
//                 },

//                 new Administrador 
//                 {
//                     nombre = "Alvaro",
//                     correo = "elalvaro@correo.com", 
//                     contrasena = "********"
//                 }
//             );

//             // guarda los cambios.
//             context.SaveChanges();
//         }

//         /// <summary>
//         /// Seeding Cliente.
//         /// </summary>
//         private static void SeedClientes(ApplicationContext context)
//         {
//             if (context.Clientes.Any()) 
//             {
//                 return;
//             }

//             context.Clientes.AddRange(
//                 new Cliente 
//                 {
//                     nombre = "Micaela",
//                     correo = "mica@correo.com", 
//                     contrasena = "********"
//                 },

//                 new Cliente 
//                 {
//                     nombre = "Roberto",
//                     correo = "roberto@correo.com", 
//                     contrasena = "********"
//                 }
//             );

//             // guarda los cambios.
//             context.SaveChanges();
//         }

//         /// <summary>
//         /// Seeding Técnico.
//         /// </summary>
//         private static void SeedTecnicos(ApplicationContext context)
//         {
//             if (context.Tecnicos.Any()) 
//             {
//                 return;
//             }

//             context.Tecnicos.AddRange(
//                 new Tecnico 
//                 {
//                     nombre = "Marcelo",
//                     correo = "marce@correo.com", 
//                     contrasena = "********", 
//                     edad = 40,
//                     presentacion = "Hola!", 
//                     nivelExperiencia = "Básico"
//                 },

//                 new Tecnico 
//                 {
//                     nombre = "Laura",
//                     correo = "laura@correo.com", 
//                     contrasena = "********", 
//                     edad = 25,
//                     presentacion = "Buen día!", 
//                     nivelExperiencia = "Avanzado"
//                 },

//                 new Tecnico 
//                 {
//                     nombre = "Diego",
//                     correo = "eldiego@correo.com", 
//                     contrasena = "********", 
//                     edad = 22,
//                     presentacion = "Buenas tardes!", 
//                     nivelExperiencia = "Básico"
//                 }
//             );

//             // guarda los cambios.
//             context.SaveChanges();
//         }

//         /// <summary>
//         /// Seeding Proyecto.
//         /// </summary>
//         private static void SeedProyectos(ApplicationContext context)
//         {
//             if (context.Proyectos.Any()) 
//             {
//                 return;
//             }

//             context.Proyectos.AddRange(
//                 new Proyecto 
//                 {
//                     nombre = "Hulk Aplasta!!!", 
//                     descripcion = "El héroe verde regresa... más enojado que nunca!"
//                 },

//                 new Proyecto 
//                 {
//                     nombre = "Docu-mental",
//                     descripcion = "Investigación." 
//                 }
//             );
//             context.SaveChanges();
//         }

//         /// <summary>
//         /// Seeding Solicitud.
//         /// </summary>
//         private static void SeedSolicitudes(ApplicationContext context)
//         {
//             if (context.Solicitudes.Any()) 
//             {
//                 return;
//             }

//             context.Solicitudes.AddRange(
//                 new Solicitud 
//                 {
//                     modoDeContrato = 1, 
//                     rolRequerido = "Camarografo", 
//                     horasContratadas = 8, 
//                     nivelExperiencia = "Básico", 
//                     observaciones = "obs..."
//                 },

//                 new Solicitud 
//                 {
//                     modoDeContrato = 2, 
//                     rolRequerido = "Luces", 
//                     horasContratadas = 10, 
//                     nivelExperiencia = "Avanzado", 
//                     observaciones = "no."
//                 },

//                 new Solicitud 
//                 {
//                     modoDeContrato = 1, 
//                     rolRequerido = "Director", 
//                     horasContratadas = 15, 
//                     nivelExperiencia = "Básico", 
//                     observaciones = "no."
//                 }
//             );
    
//             // guarda los cambios.
//             context.SaveChanges();
//         }

//         /// <summary>
//         /// Seeding Rol.
//         /// </summary>
//         private static void SeedRoles(ApplicationContext context)
//         {
//             if (context.Roles.Any()) 
//             {
//                 return;
//             }

//             context.Roles.AddRange(
//                 new Rol 
//                 {
//                     nombre = "Cámara", 
//                     descripcion = "."
//                 },

//                 new Rol 
//                 {
//                     nombre = "Luces", 
//                     descripcion = ".."
//                 },

//                 new Rol 
//                 {
//                     nombre = "Director",
//                     descripcion = "..." 
//                 }
//             );
//             context.SaveChanges();
//         }
//     } 
// }
