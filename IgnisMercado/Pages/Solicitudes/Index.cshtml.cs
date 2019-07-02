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

        public Solicitud Solicitud { get; set; }

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

                this.TecnicosAsignados = solicitud.RelacionTecnicoSolicitud 
                                            .Select(r => r.Tecnico);
                                            
                this.TecnicosDisponibles = await _context.Tecnicos
                                                .Where(t => !TecnicosAsignados.Contains(t))
                                                .ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostDesasignarTecnicoAsync(int id, string TecnicoIdDesasignado) 
        {
            // Selecciono la solicitud para actualizar.
            Solicitud solicitudActualizada = await _context.Solicitudes 
                .Include(s => s.RelacionTecnicoSolicitud)
                    .ThenInclude(r => r.Tecnico)
                .FirstOrDefaultAsync(m => m.SolicitudId == id);

            // await TryUpdateModelAsync<Solicitud>(solicitudActualizada);

            // Selecciono el técnico especifico a partir de la solicitud involucrada.
            var TecnicoDesasignado = solicitudActualizada.RelacionTecnicoSolicitud
                                        .Where(a => a.TecnicoId == TecnicoIdDesasignado).FirstOrDefault();

            // Sí tiene un técnico, lo elimino de la solicitud.
            if (TecnicoDesasignado != null)
            {
                solicitudActualizada.RelacionTecnicoSolicitud.Remove(TecnicoDesasignado);
            }

            // Guardar los cambios
            await _context.SaveChangesAsync();

            // Recargar la página al index.
            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostAsignarTecnicoAsync(int? id, string TecnicoIdAsignado) 
        {
            // Selecciono la solicitud para actualizar.
            Solicitud solicitudActualizada = await _context.Solicitudes 
                .Include(s => s.RelacionTecnicoSolicitud)
                    .ThenInclude(r => r.Tecnico)
                .FirstOrDefaultAsync(m => m.SolicitudId == id);

            

            // Sí tiene un técnico, lo elimino de la solicitud.
            if (TecnicoIdAsignado != null)
            {
                await TryUpdateModelAsync<Solicitud>(solicitudActualizada);

                // Seleccionar técnico.
                ApplicationUser TecnicoAsignado = await _context.Users
                    .Where(u => u.Id == TecnicoIdAsignado).FirstOrDefaultAsync();                

                if (TecnicoAsignado != null) 
                { 
                    // Definir la relación que tengo que crear.
                    var RTecnicoSolicitudNueva = new RelacionTecnicoSolicitud() {
                        TecnicoId = TecnicoIdAsignado, 
                        Tecnico = TecnicoAsignado, 
                        SolicitudId = solicitudActualizada.SolicitudId, 
                        Solicitud = solicitudActualizada };

                    solicitudActualizada.RelacionTecnicoSolicitud.Add(RTecnicoSolicitudNueva);
                }
            }

            // Guardar los cambios
            await _context.SaveChangesAsync();

            // Recargar la página al index.
            return RedirectToPage("./Index");
        }
    }
}
