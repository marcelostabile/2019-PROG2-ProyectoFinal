using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using IgnisMercado.Areas.Identity.Data;
using IgnisMercado.Models;

namespace IgnisMercado.Models.Seeding 
{
    /// <summary>
    /// Inicializa la base de datos.
    /// </summary>
    public class Seeding
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Seeding roles.
            SeedRoles(roleManager);

            // Seeding usuarios.
            SeedUsuarios(userManager);

            using (var context = new ApplicationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationContext>>()))
            {
                // Seeding costos.
                SeedCostos(context);

                // Seeding proyectos.
                SeedProyectos(context);

                // Seeding solicitudes.
                SeedSolicitudes(context);

                // Seeding relaciones.
                SeedRClienteProyectos(context);

                SeedRProyectoSolicitudes(context);

                SeedRTecnicoRoles(context);

                // Seeding roles.
                SeedRol(context);
            }
        }

        // Seeding usuarios.
        private static void SeedUsuarios(UserManager<ApplicationUser> userManager)
        {
            // Instanciar SeedUserData.
            SeedUserData seedUserData = new SeedUserData();

            // Cargar la lista de usuarios.
            seedUserData.CargarListaUsuarios();

            foreach (SeedUser user in seedUserData.ListaUsuarios) 
            {
                // Verificación de existencia. 
                if (userManager.FindByNameAsync(user.UserName).Result == null)
                {
                    // Datos del usuario.
                    ApplicationUser AppUser = new ApplicationUser();
                    AppUser.Name = user.Name;
                    AppUser.UserName = user.UserName;
                    AppUser.Email = user.Email;
                    AppUser.DOB = user.DOB;

                    // Status activo.
                    AppUser.StatusHabilitar();

                    // Asignamos un role.
                    AppUser.AssignRole(userManager, user.UserType);

                    IdentityResult result = userManager.CreateAsync(AppUser, user.Password).Result;

                    AddToRole(userManager, result, AppUser);

                }
            }
        }

        // Role.
        private static void AddToRole(UserManager<ApplicationUser> userManager, IdentityResult result, ApplicationUser AppUser) 
        {
            if (result.Succeeded)
            {
                IdentityResult addRoleResult = userManager.AddToRoleAsync(AppUser, AppUser.Role).Result;

                if (!addRoleResult.Succeeded)
                {
                    throw new InvalidOperationException(
                        $"Unexpected error ocurred adding role '{AppUser.Role}' to user '{AppUser.Name}'.");
                }
            }
            else
            {
                throw new InvalidOperationException($"Unexpected error ocurred creating user '{AppUser.Name}'.");
            }
        }

        // Crear un Role.
        private static void CreateRole(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (!roleManager.RoleExistsAsync(roleName).Result)
            {
                IdentityRole role = new IdentityRole(roleName);

                IdentityResult createRoleResult = roleManager.CreateAsync(role).Result;

                if (!createRoleResult.Succeeded)
                {
                    throw new InvalidOperationException($"Unexpected error ocurred creating role '{role}'.");
                }
            }
        }

        // Crear un Role para Administrador.
        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            CreateRole(roleManager, SeedUserData.AdminRole);

            foreach (var roleName in SeedUserData.NonAdminRole)
            {
                CreateRole(roleManager, roleName);
            }
        }

        /// <summary>
        /// Seeding Proyectos.
        /// </summary>
        private static void SeedProyectos(ApplicationContext context)
        {
            if (context.Proyectos.Any()) 
            {
                return;
            }

            context.Proyectos.AddRange(
                new Proyecto 
                { 
                    Nombre = "Ataque de pánico", 
                    Descripcion = "Cortometraje ciencia ficción.", 
                    Status = true
                },
                new Proyecto 
                {
                    Nombre = "El vendedor de humo",
                    Descripcion = "Cortometraje animación.",
                    Status = true
                },
                new Proyecto 
                { 
                    Nombre = "It´s a bird thing", 
                    Descripcion = "Cortometraje animación.",
                    Status = true
                },
                new Proyecto 
                {
                    Nombre = "La cabeza me da vueltas",
                    Descripcion = "	Cortometraje documental.",
                    Status = true
                },
                new Proyecto 
                {
                    Nombre = "La luna",
                    Descripcion = "Cortometraje aventura.",
                    Status = true
                },
                new Proyecto 
                {
                    Nombre = "Mi peluquera ideal",
                    Descripcion = "Cortometraje comedia.",
                    Status = true
                }
            );

            // guarda los cambios.
            context.SaveChanges();
            
            // Cuando se crea el proyecto, status queda inactivo. Aquí lo actualizo a true.
            var proys = context.Proyectos;

            foreach(var proy in proys) proy.StatusActivo();

            // guarda los cambios.
            context.SaveChanges();
        }

        /// <summary>
        /// Seeding RelacionClienteProyectos.
        /// </summary>
        private static void SeedRClienteProyectos(ApplicationContext context)
        {
            if (context.RelacionClienteProyectos.Any()) 
            {
                return;
            }

            context.RelacionClienteProyectos.AddRange(
                new RelacionClienteProyecto { ClienteId = "a2098bab-6c99-4128-b5b3-6034591b1e7e", ProyectoId = 1 },
                new RelacionClienteProyecto { ClienteId = "a2098bab-6c99-4128-b5b3-6034591b1e7e", ProyectoId = 2 },

                new RelacionClienteProyecto { ClienteId = "48ca5c77-f5bf-4d98-bb5d-a7f7390a8a78", ProyectoId = 3 },
                new RelacionClienteProyecto { ClienteId = "48ca5c77-f5bf-4d98-bb5d-a7f7390a8a78", ProyectoId = 4 },

                new RelacionClienteProyecto { ClienteId = "f2a27645-bd52-455b-b622-212c0b832794", ProyectoId = 5 },
                new RelacionClienteProyecto { ClienteId = "f2a27645-bd52-455b-b622-212c0b832794", ProyectoId = 6 }
            );

            // guarda los cambios.
            context.SaveChanges();
        }

        /// <summary>
        /// Seeding RelacionProyectoSolicitudes.
        /// </summary>
        private static void SeedRProyectoSolicitudes(ApplicationContext context)
        {
            if (context.RelacionProyectoSolicitudes.Any()) 
            {
                return;
            }

            context.RelacionProyectoSolicitudes.AddRange(
                new RelacionProyectoSolicitud {ProyectoId = 1, SolicitudId = 1},
                new RelacionProyectoSolicitud {ProyectoId = 1, SolicitudId = 2},
                new RelacionProyectoSolicitud {ProyectoId = 2, SolicitudId = 3},
                new RelacionProyectoSolicitud {ProyectoId = 2, SolicitudId = 4},
                new RelacionProyectoSolicitud {ProyectoId = 3, SolicitudId = 5},
                new RelacionProyectoSolicitud {ProyectoId = 3, SolicitudId = 6},
                new RelacionProyectoSolicitud {ProyectoId = 4, SolicitudId = 7},
                new RelacionProyectoSolicitud {ProyectoId = 4, SolicitudId = 8}
            );

            // guarda los cambios.
            context.SaveChanges();
        }

        /// <summary>
        /// Seeding RelacionTecnicoRoles.
        /// </summary>
        private static void SeedRTecnicoRoles(ApplicationContext context)
        {
            if (context.RelacionTecnicoRoles.Any()) 
            {
                return;
            }

            context.RelacionTecnicoRoles.AddRange(
                new RelacionTecnicoRol {TecnicoId = "57bf6b3f-26f0-4eaa-9f66-14b3e6fdfce2", RolId = 11},
                new RelacionTecnicoRol {TecnicoId = "57bf6b3f-26f0-4eaa-9f66-14b3e6fdfce2", RolId = 18},

                new RelacionTecnicoRol {TecnicoId = "0626bd2e-c394-4f89-bb52-8dcf01b0128c", RolId = 17},
                new RelacionTecnicoRol {TecnicoId = "0626bd2e-c394-4f89-bb52-8dcf01b0128c", RolId = 19},
                new RelacionTecnicoRol {TecnicoId = "0626bd2e-c394-4f89-bb52-8dcf01b0128c", RolId = 21},

                new RelacionTecnicoRol {TecnicoId = "cf374546-893e-4b69-8622-a334fb02ade8", RolId = 3},
                new RelacionTecnicoRol {TecnicoId = "cf374546-893e-4b69-8622-a334fb02ade8", RolId = 6},
                new RelacionTecnicoRol {TecnicoId = "cf374546-893e-4b69-8622-a334fb02ade8", RolId = 8}
            );

            // guarda los cambios.
            context.SaveChanges();
        }

        /// <summary>qq
        /// Seeding Costos.
        /// </summary>
        private static void SeedCostos(ApplicationContext context)
        {
            if (context.Costos.Any()) 
            {
                return;
            }

            context.Costos.AddRange(
                new Costo 
                {
                    CostoHoraBasico = 150,
                    CostoHoraAvanzado = 280,
                    PrimeraHoraBasico = 380,
                    PrimeraHoraAvanzado = 520,
                    JornadaAvanzado=2000,
                    JornadaBasico=1200,
                    HoraJornada=6
                }
            );

            // guarda los cambios.
            context.SaveChanges();
        }

        /// <summary>
        /// Seeding Solicitud.
        /// </summary>
        private static void SeedSolicitudes(ApplicationContext context)
        {
            if (context.Solicitudes.Any()) 
            {
                return;
            }

            context.Solicitudes.AddRange(
                new Solicitud 
                {
                    SolicitudId = 1,
                    ModoDeContrato = 1, 
                    RolRequerido = "Operador de Cabina 03 y Estudio de Radio", 
                    HorasContratadas = 8, 
                    NivelExperiencia = "Básico", 
                    Observaciones = "s/obs."
                },
                new Solicitud 
                {
                    SolicitudId = 2,
                    ModoDeContrato = 2, 
                    RolRequerido = "Sonidista", 
                    HorasContratadas = 10, 
                    NivelExperiencia = "Avanzado", 
                    Observaciones = "s/obs."
                },
                new Solicitud 
                {
                    SolicitudId = 3,
                    ModoDeContrato = 1, 
                    RolRequerido = "Presentador / conductor", 
                    HorasContratadas = 15, 
                    NivelExperiencia = "Básico", 
                    Observaciones = "s/obs."
                },
                new Solicitud 
                {
                    SolicitudId = 4,
                    ModoDeContrato = 1, 
                    RolRequerido = "Sonidista", 
                    HorasContratadas = 8, 
                    NivelExperiencia = "Básico", 
                    Observaciones = "s/obs."
                },
                new Solicitud 
                {
                    SolicitudId = 5,
                    ModoDeContrato = 2, 
                    RolRequerido = "Redactor creativo", 
                    HorasContratadas = 10, 
                    NivelExperiencia = "Avanzado", 
                    Observaciones = "s/obs."
                },
                new Solicitud 
                {
                    SolicitudId = 6,
                    ModoDeContrato = 1, 
                    RolRequerido = "Operador de Cabina 02", 
                    HorasContratadas = 15, 
                    NivelExperiencia = "Básico", 
                    Observaciones = "s/obs."
                },
                new Solicitud 
                {
                    SolicitudId = 7,
                    ModoDeContrato = 1, 
                    RolRequerido = "Diseñador gráfico", 
                    HorasContratadas = 8, 
                    NivelExperiencia = "Básico", 
                    Observaciones = "s/obs."
                },
                new Solicitud 
                {
                    SolicitudId = 8,
                    ModoDeContrato = 2, 
                    RolRequerido = "Cámara y asistente de cámara", 
                    HorasContratadas = 10, 
                    NivelExperiencia = "Avanzado", 
                    Observaciones = "s/obs."
                }
            );

            // guarda los cambios.
            context.SaveChanges();
            
            // Cuando se crea la solicitud en context, queda a costo cero y status inactivo.
            // Actualizo el status y el costo de cada solicitud de acuerdo al precio vigente.
            var solicitudes = context.Solicitudes;

            ICosto Costo = new Costo();

            foreach(var s in solicitudes)
            {
                s.costoSolicitud = Costo.CalcularCostoSolicitud(
                                            s.ModoDeContrato,
                                            s.HorasContratadas,
                                            s.NivelExperiencia);

                s.StatusActivo();
            }

            // guarda los cambios.
            context.SaveChanges();
        }

        /// <summary>
        /// Seeding Rol.
        /// </summary>
        private static void SeedRol(ApplicationContext context)
        {
            if (context.Roles.Any()) 
            {
                return;
            }

            context.Roles.AddRange(
                new Rol {Nivel = "Básico", Descripcion = "Foto fija"},
                new Rol {Nivel = "Básico", Descripcion = "Asistente de cámara"},
                new Rol {Nivel = "Básico", Descripcion = "Asistente de producción"},
                new Rol {Nivel = "Básico", Descripcion = "Asistente de dirección"},
                new Rol {Nivel = "Básico", Descripcion = "Asistente de arte (escenografía, vestuario, utilería)"},
                new Rol {Nivel = "Básico", Descripcion = "Sonidista"},
                new Rol {Nivel = "Básico", Descripcion = "Editor"},
                new Rol {Nivel = "Básico", Descripcion = "Redactor creativo"},
                new Rol {Nivel = "Básico", Descripcion = "Presentador / conductor"},
                new Rol {Nivel = "Básico", Descripcion = "Ilustrador"},
                new Rol {Nivel = "Básico", Descripcion = "Diseñador gráfico"},
                new Rol {Nivel = "Básico", Descripcion = "Operador de Cabina 02"},
                new Rol {Nivel = "Básico", Descripcion = "Operador de Cabina 03 y Estudio de Radio"},

                new Rol {Nivel = "Avanzado", Descripcion = "Foto fija"},
                new Rol {Nivel = "Avanzado", Descripcion = "Cámara y asistente de cámara"},
                new Rol {Nivel = "Avanzado", Descripcion = "Cámara 360º"},
                new Rol {Nivel = "Avanzado", Descripcion = "Postproductor de imagen"},
                new Rol {Nivel = "Avanzado", Descripcion = "Editor"},
                new Rol {Nivel = "Avanzado", Descripcion = "Sonidista"},
                new Rol {Nivel = "Avanzado", Descripcion = "Postproductor de sonido"},
                new Rol {Nivel = "Avanzado", Descripcion = "Redactor creativo"},
                new Rol {Nivel = "Avanzado", Descripcion = "Presentador / conductor"},
                new Rol {Nivel = "Avanzado", Descripcion = "Animador / infografista"},
                new Rol {Nivel = "Avanzado", Descripcion = "Operador de Cabina 01 Estudio de Grabación"}
            );

            // guarda los cambios.
            context.SaveChanges();
        }

    }
}
