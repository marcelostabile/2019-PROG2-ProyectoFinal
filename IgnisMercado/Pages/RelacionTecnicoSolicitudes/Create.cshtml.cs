using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IgnisMercado.Models;

namespace IgnisMercado.Pages.RelacionTecnicoSolicitudes
{
    public class CreateModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public CreateModel(IgnisMercado.Models.ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SolicitudId"] = new SelectList(_context.Solicitudes, "SolicitudId", "RolRequerido");
        ViewData["TecnicoId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public RelacionTecnicoSolicitud RelacionTecnicoSolicitud { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RelacionTecnicoSolicitudes.Add(RelacionTecnicoSolicitud);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}