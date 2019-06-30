using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IgnisMercado.Models;

namespace IgnisMercado.Pages.RelacionClienteProyectos
{
    public class EditModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public EditModel(IgnisMercado.Models.ApplicationContext context)
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
           ViewData["ClienteId"] = new SelectList(_context.Users, "Id", "Id");
           ViewData["ProyectoId"] = new SelectList(_context.Proyectos, "ProyectoId", "Descripcion");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RelacionClienteProyecto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RelacionClienteProyectoExists(RelacionClienteProyecto.ClienteId))
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

        private bool RelacionClienteProyectoExists(string id)
        {
            return _context.RelacionClienteProyectos.Any(e => e.ClienteId == id);
        }
    }
}
