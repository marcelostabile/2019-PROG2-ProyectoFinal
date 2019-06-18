using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IgnisMercado;
using IgnisMercado.Data;

namespace IgnisMercado.Pages.Administradores
{
    public class DeleteModel : PageModel
    {
        private readonly IgnisMercado.Data.ApplicationDbContext _context;

        public DeleteModel(IgnisMercado.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Administrador Administrador { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Administrador = await _context.Administrador.FirstOrDefaultAsync(m => m.Id == id);

            if (Administrador == null)
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

            Administrador = await _context.Administrador.FindAsync(id);

            if (Administrador != null)
            {
                _context.Administrador.Remove(Administrador);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
