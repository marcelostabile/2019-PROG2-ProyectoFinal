using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IgnisMercado.Models;

namespace IgnisMercado.Pages.RelacionTecnicoSolicitudes
{
    public class DeleteModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public DeleteModel(IgnisMercado.Models.ApplicationContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RelacionTecnicoSolicitud = await _context.RelacionTecnicoSolicitudes.FindAsync(id);

            if (RelacionTecnicoSolicitud != null)
            {
                _context.RelacionTecnicoSolicitudes.Remove(RelacionTecnicoSolicitud);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
