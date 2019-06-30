using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using IgnisMercado.Models;
using IgnisMercado.Areas.Identity.Data;
using IgnisMercado.Models.ClienteViewModels;

namespace IgnisMercado.Pages.Proyectos
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

        public int? ProyectoId { get; set; }

        public ClienteIndexData ClienteIdxData = new ClienteIndexData();

        public async Task OnGetAsync(int? id)
        {
            // Mostramos en pantalla la lista de todos los proyectos.
            ClienteIdxData.Proyectos = await _context.Proyectos 
                .Include(p=>p.RelacionProyectoSolicitud)
                    .ThenInclude(r=>r.Solicitud)
                        .OrderBy(p => p.Nombre)
                            .AsNoTracking()
                            .ToListAsync();

                // Solicitudes.
                if (id != null) 
                { 
                    // El usuario selecciona un proyecto del cliente.
                    ProyectoId = id;

                    ClienteIdxData.Proyectos = await _context.Proyectos 
                        .Where(p=>p.ProyectoId == id)
                        .Include(p=>p.RelacionProyectoSolicitud)
                            .ThenInclude(r=>r.Solicitud)
                                .OrderBy(p => p.Nombre)
                                    .AsNoTracking()
                                    .ToListAsync();

                    Proyecto proyecto = ClienteIdxData.Proyectos
                                            .Where(p => p.ProyectoId == id).Single();

                    ClienteIdxData.Solicitudes = proyecto.RelacionProyectoSolicitud
                                                    .Select(rps => rps.Solicitud).ToList();

                };
        }
    }
}
