using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IgnisMercado.Models;

namespace IgnisMercado.Pages.RelacionClienteProyectos
{
    public class DetailsModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public DetailsModel(IgnisMercado.Models.ApplicationContext context)
        {
            _context = context;
        }

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
    }
}
