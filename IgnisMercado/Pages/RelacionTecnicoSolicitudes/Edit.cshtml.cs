using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IgnisMercado.Models;

namespace IgnisMercado.Pages.RelacionTecnicoSolicitudes
{
    public class EditModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public EditModel(IgnisMercado.Models.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RelacionTecnicoSolicitud RelacionTecnicoSolicitud { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RelacionTecnicoSolicitud = await _context.RelacionTecnicoSolicitudes
                .Include(r => r.Solicitud)
                .Include(r => r.Tecnico).FirstOrDefaultAsync(m => m.TecnicoId == id);

            if (RelacionTecnicoSolicitud == null)
            {
                return NotFound();
            }
           ViewData["SolicitudId"] = new SelectList(_context.Solicitudes, "SolicitudId", "RolRequerido");
           ViewData["TecnicoId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RelacionTecnicoSolicitud).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RelacionTecnicoSolicitudExists(RelacionTecnicoSolicitud.TecnicoId))
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

        private bool RelacionTecnicoSolicitudExists(string id)
        {
            return _context.RelacionTecnicoSolicitudes.Any(e => e.TecnicoId == id);
        }
    }
}
