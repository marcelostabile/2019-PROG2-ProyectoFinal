using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IgnisMercado.Models;

namespace IgnisMercado.Pages.Costos
{
    public class DeleteModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public DeleteModel(IgnisMercado.Models.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Costo Costo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Costo = await _context.Costos.FirstOrDefaultAsync(m => m.Id == id);

            if (Costo == null)
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

            Costo = await _context.Costos.FindAsync(id);

            if (Costo != null)
            {
                _context.Costos.Remove(Costo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
