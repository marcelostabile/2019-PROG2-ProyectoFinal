using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using IgnisMercado.Areas.Identity.Data;

namespace IgnisMercado.Pages.Tecnicos
{
    public class DetailsModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public DetailsModel(IgnisMercado.Models.ApplicationContext context)
        {
            _context = context;
        }

        public ApplicationUser Tecnico { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tecnico = await _context.Tecnicos.FirstOrDefaultAsync(m => m.Id == id);

            if (Tecnico == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
