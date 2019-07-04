using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IgnisMercado.Models;

namespace IgnisMercado.Pages.RelacionTecnicoRoles
{
    public class DeleteModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public DeleteModel(IgnisMercado.Models.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RelacionTecnicoRol RelacionTecnicoRol { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RelacionTecnicoRol = await _context.RelacionTecnicoRoles
                .Include(r => r.Rol)
                .Include(r => r.Tecnico).FirstOrDefaultAsync(m => m.TecnicoId == id);

            if (RelacionTecnicoRol == null)
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

            RelacionTecnicoRol = await _context.RelacionTecnicoRoles.FindAsync(id);

            if (RelacionTecnicoRol != null)
            {
                _context.RelacionTecnicoRoles.Remove(RelacionTecnicoRol);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
