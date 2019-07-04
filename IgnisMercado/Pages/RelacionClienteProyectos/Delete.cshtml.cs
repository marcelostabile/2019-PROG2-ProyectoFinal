using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IgnisMercado.Models;

namespace IgnisMercado.Pages.RelacionClienteProyectos
{
    public class DeleteModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public DeleteModel(IgnisMercado.Models.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RelacionClienteProyecto RelacionClienteProyecto { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RelacionClienteProyecto = await _context.RelacionClienteProyectos
                .Include(r => r.Cliente)
                .Include(r => r.Proyecto).FirstOrDefaultAsync(m => m.ClienteId == id);

            if (RelacionClienteProyecto == null)
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

            RelacionClienteProyecto = await _context.RelacionClienteProyectos.FindAsync(id);

            if (RelacionClienteProyecto != null)
            {
                _context.RelacionClienteProyectos.Remove(RelacionClienteProyecto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
