using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IgnisMercado.Models;

namespace IgnisMercado.Pages.Proyectos
{
    public class DeleteModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public DeleteModel(IgnisMercado.Models.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Proyecto Proyecto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Proyecto = await _context.Proyecto.FirstOrDefaultAsync(m => m.Id == id);

            if (Proyecto == null)
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

            Proyecto = await _context.Proyecto.FindAsync(id);

            if (Proyecto != null)
            {
                _context.Proyecto.Remove(Proyecto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
