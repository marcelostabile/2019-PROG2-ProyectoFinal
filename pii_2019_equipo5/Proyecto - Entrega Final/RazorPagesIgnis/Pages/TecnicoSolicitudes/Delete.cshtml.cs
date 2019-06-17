using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesIgnis;
using RazorPagesIgnis.Models;

namespace RazorPagesIgnis.Pages.tecnicoSolicitudes
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesIgnis.Models.IgnisContext _context;

        public DeleteModel(RazorPagesIgnis.Models.IgnisContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TecnicoSolicitud = await _context.TecnicoSolicitudes.FindAsync(id);

            if (TecnicoSolicitud != null)
            {
                _context.TecnicoSolicitudes.Remove(TecnicoSolicitud);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
