using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesIgnis;
using RazorPagesIgnis.Models;

namespace RazorPagesIgnis.Pages.solicitudes
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesIgnis.Models.IgnisContext _context;

        public DeleteModel(RazorPagesIgnis.Models.IgnisContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Solicitud Solicitud { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Solicitud = await _context.Solicitudes.FirstOrDefaultAsync(m => m.ID == id);

            if (Solicitud == null)
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

            Solicitud = await _context.Solicitudes.FindAsync(id);

            if (Solicitud != null)
            {
                _context.Solicitudes.Remove(Solicitud);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
