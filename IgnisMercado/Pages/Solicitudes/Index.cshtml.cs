using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using IgnisMercado.Areas.Identity.Data;
using IgnisMercado.Models;
using IgnisMercado.Models.ViewModels;

namespace IgnisMercado.Pages.Solicitudes
{
    public class IndexModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public IndexModel(IgnisMercado.Models.ApplicationContext context)
        {
            _context = context;
        }

        public int? SolicitudId { get;set; }

        public string TecnicoId { get;set; }

        public SolicitudIndexData SolicitudIdx = new SolicitudIndexData();

        public IEnumerable<ApplicationUser> TecnicosAsignados { get; set; }

        public IEnumerable<ApplicationUser> TecnicosDisponibles { get; set; }

        public async Task OnGetAsync(int? id)
        { 
            if (id == null)
            {
                SolicitudIdx.Solicitudes = await _context.Solicitudes 
                    .Include(s => s.RelacionTecnicoSolicitud)
                        .ThenInclude(r => r.Tecnico)
                            .OrderBy(s => s.RolRequerido)
                            .OrderByDescending(s => s.NivelExperiencia)
                                .AsNoTracking()
                                .ToListAsync();

            }
            else
            {
                SolicitudId = id;

                // Cuando se selecciona una solicitud, mostramos solo la solicitud seleccionada.
                SolicitudIdx.Solicitudes = await _context.Solicitudes 
                    .Where(s => s.SolicitudId == id)
                    .Include(s => s.RelacionTecnicoSolicitud)
                        .ThenInclude(r => r.Tecnico)
                            .OrderBy(s => s.RolRequerido)
                            .OrderByDescending(s => s.NivelExperiencia)
                                .AsNoTracking()
                                .ToListAsync();

                Solicitud solicitud = SolicitudIdx.Solicitudes 
                                        .Where(s => s.SolicitudId == id).Single();

                SolicitudIdx.Tecnicos = solicitud.RelacionTecnicoSolicitud 
                                        .Select(r => r.Tecnico).ToList();

            }
        }
    }
}
