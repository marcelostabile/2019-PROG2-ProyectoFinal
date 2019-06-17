using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesIgnis;
using RazorPagesIgnis.Models;

namespace RazorPagesIgnis.Pages.tecnicoSolicitudes
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesIgnis.Models.IgnisContext _context;

        public EditModel(RazorPagesIgnis.Models.IgnisContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TecnicoSolicitud TecnicoSolicitud { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TecnicoSolicitud = await _context.TecnicoSolicitudes
                .Include(t => t.Solicitud)
                .Include(t => t.Tecnico).FirstOrDefaultAsync(m => m.tecnicoID == id);

            if (TecnicoSolicitud == null)
            {
                return NotFound();
            }
           ViewData["solicitudID"] = new SelectList(_context.Solicitudes, "ID", "ID");
           ViewData["tecnicoID"] = new SelectList(_context.Tecnicos, "ID", "ID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TecnicoSolicitud).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TecnicoSolicitudExists(TecnicoSolicitud.tecnicoID))
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

        private bool TecnicoSolicitudExists(int id)
        {
            return _context.TecnicoSolicitudes.Any(e => e.tecnicoID == id);
        }
    }
}
