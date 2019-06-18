using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IgnisMercado;
using IgnisMercado.Data;

namespace IgnisMercado.Pages.Proyectos
{
    public class DetailsModel : PageModel
    {
        private readonly IgnisMercado.Data.ApplicationDbContext _context;

        public DetailsModel(IgnisMercado.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Proyecto Proyecto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Proyecto = await _context.Proyecto.FirstOrDefaultAsync(m => m.Id == id);

            if (Proyecto == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
