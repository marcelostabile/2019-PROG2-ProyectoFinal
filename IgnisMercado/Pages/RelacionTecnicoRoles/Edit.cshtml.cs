using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IgnisMercado.Models;

namespace IgnisMercado.Pages.RelacionTecnicoRoles
{
    public class EditModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public EditModel(IgnisMercado.Models.ApplicationContext context)
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
           ViewData["RolId"] = new SelectList(_context.Roles, "RolId", "Nivel");
           ViewData["TecnicoId"] = new SelectList(_context.Tecnicos, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RelacionTecnicoRol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RelacionTecnicoRolExists(RelacionTecnicoRol.TecnicoId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RelacionTecnicoRolExists(string id)
        {
            return _context.RelacionTecnicoRoles.Any(e => e.TecnicoId == id);
        }
    }
}
