using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesIgnis;
using RazorPagesIgnis.Models;

namespace RazorPagesIgnis.Pages.proyectos
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesIgnis.Models.IgnisContext _context;

        public DetailsModel(RazorPagesIgnis.Models.IgnisContext context)
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

            Proyecto = await _context.Proyectos.FirstOrDefaultAsync(m => m.ID == id);

            if (Proyecto == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
