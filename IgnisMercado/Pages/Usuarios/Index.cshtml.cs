using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using IgnisMercado.Models;
using IgnisMercado.Areas.Identity.Data;
using IgnisMercado.Models.ViewModels;

namespace IgnisMercado.Pages.Usuarios
{
    public class IndexModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(IgnisMercado.Models.ApplicationContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;

            _userManager = userManager;
        }

        public string ClienteId { get; set; }

        public int? ProyectoId { get; set; }

        public ClienteIndexData ClienteIdxData = new ClienteIndexData();

        public async Task OnGetAsync(string id, int proyId)
        { 
            
            if (id == null)
            {
                // Mostramos en pantalla la lista de todos los usuarios.
                ClienteIdxData.Usuarios = await _context.Users
                    .Include(u => u.RelacionClienteProyecto)
                        .ThenInclude(rcp => rcp.Proyecto)
                            .OrderBy(u => u.Name)
                            .OrderBy(u => u.Role)
                            .AsNoTracking()
                            .ToListAsync();
            }
            else 
            {
                // El usuario selecciona en pantalla a un usuario (id != null).
                ClienteId = id;

                // Mostramos en pantalla solo el usuario seleccionado.
                // Decidimos redefinir aquí el viewmodel Usuarios mediante una condición where
                // para evitar agregar en la vista parte de la lógica de filtrado.
                // Toda la lógica de seleccionar el usuario queda en el controlador.
                ClienteIdxData.Usuarios = await _context.Users
                    .Where(u => u.Id == id)
                    .Include(u => u.RelacionClienteProyecto)
                        .ThenInclude(rcp => rcp.Proyecto)
                            .ThenInclude(p => p.RelacionProyectoSolicitud)  
                                .ThenInclude(rps => rps.Solicitud)
                                    .AsNoTracking()
                                    .ToListAsync();

                ApplicationUser usuario = ClienteIdxData.Usuarios
                                            .Where(u => u.Id == id).Single();

                ClienteIdxData.Proyectos = usuario.RelacionClienteProyecto 
                                            .Select(r => r.Proyecto).ToList();

                // Solicitudes.
                if (proyId != 0) 
                { 
                    // El usuario selecciona un proyecto del cliente.
                    ProyectoId = proyId;

                    Proyecto proyecto = ClienteIdxData.Proyectos
                                            .Where(p => p.ProyectoId == proyId).Single();

                    ClienteIdxData.Solicitudes = proyecto.RelacionProyectoSolicitud
                                                    .Select(rps => rps.Solicitud).ToList();

                };
            };
           
        }
    }
}
