using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IgnisMercado.Models;

namespace IgnisMercado.Pages.RelacionProyectoSolicitudes
{
    public class DeleteModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public DeleteModel(IgnisMercado.Models.ApplicationContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RelacionProyectoSolicitud = await _context.RelacionProyectoSolicitudes.FindAsync(id);

            if (RelacionProyectoSolicitud != null)
            {
                _context.RelacionProyectoSolicitudes.Remove(RelacionProyectoSolicitud);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
