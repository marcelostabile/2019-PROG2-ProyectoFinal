using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IgnisMercado.Models;

namespace IgnisMercado.Pages.RelacionProyectoSolicitudes
{
    public class EditModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public EditModel(IgnisMercado.Models.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RelacionProyectoSolicitud RelacionProyectoSolicitud { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RelacionProyectoSolicitud = await _context.RelacionProyectoSolicitudes
                .Include(r => r.Proyecto)
                .Include(r => r.Solicitud).FirstOrDefaultAsync(m => m.ProyectoId == id);

            if (RelacionProyectoSolicitud == null)
            {
                return NotFound();
            }
           ViewData["ProyectoId"] = new SelectList(_context.Proyectos, "ProyectoId", "Descripcion");
           ViewData["SolicitudId"] = new SelectList(_context.Solicitudes, "SolicitudId", "SolicitudId");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RelacionProyectoSolicitud).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RelacionProyectoSolicitudExists(RelacionProyectoSolicitud.ProyectoId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RelacionProyectoSolicitudExists(int id)
        {
            return _context.RelacionProyectoSolicitudes.Any(e => e.ProyectoId == id);
        }
    }
}
