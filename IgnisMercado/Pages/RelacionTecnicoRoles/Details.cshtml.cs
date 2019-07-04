using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IgnisMercado.Models;

namespace IgnisMercado.Pages.RelacionTecnicoRoles
{
    public class DetailsModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public DetailsModel(IgnisMercado.Models.ApplicationContext context)
        {
            _context = context;
        }

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
    }
}
