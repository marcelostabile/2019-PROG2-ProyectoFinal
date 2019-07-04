using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IgnisMercado.Models;

namespace IgnisMercado.Pages.Costos
{
    public class EditModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public EditModel(IgnisMercado.Models.ApplicationContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Costo).State = EntityState.Modified;

            try
            {
                // Se guardan los cambios.
                await _context.SaveChangesAsync();

                // Se actualiza el costo en todas las solicitudes activas.
                // Se controla la condicion en ActualizarCostoSolicitudActiva().
                foreach (Solicitud sol in _context.Solicitudes)
                {
                    sol.ActualizarCostoSolicitudActiva();
                }

                // Se guarda la actualizacion de precios en las solicitudes.
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CostoExists(Costo.Id))
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

        private bool CostoExists(int id)
        {
            return _context.Costos.Any(e => e.Id == id);
        }
    }
}
