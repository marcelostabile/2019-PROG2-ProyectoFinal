using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IgnisMercado.Models;

namespace IgnisMercado.Pages.Solicitudes
{
    public class EditModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public EditModel(IgnisMercado.Models.ApplicationContext context)
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

            Solicitud = await _context.Solicitudes.FirstOrDefaultAsync(m => m.SolicitudId == id);

            if (Solicitud == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Solicitud).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                // Se actualiza el costo en todas las solicitudes activas.
                foreach (Solicitud sol in _context.Solicitudes)
                {
                    sol.ActualizarCostoSolicitudActiva();
                }

                // Se guarda la actualizacion de precios en las solicitudes.
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolicitudExists(Solicitud.SolicitudId))
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

        private bool SolicitudExists(int id)
        {
            return _context.Solicitudes.Any(e => e.SolicitudId == id);
        }
    }
}
