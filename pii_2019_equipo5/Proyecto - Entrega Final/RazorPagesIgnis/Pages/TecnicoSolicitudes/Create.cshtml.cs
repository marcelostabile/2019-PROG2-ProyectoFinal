using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesIgnis;
using RazorPagesIgnis.Models;

namespace RazorPagesIgnis.Pages.tecnicoSolicitudes
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesIgnis.Models.IgnisContext _context;

        public CreateModel(RazorPagesIgnis.Models.IgnisContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["solicitudID"] = new SelectList(_context.Solicitudes, "ID", "ID");
        ViewData["tecnicoID"] = new SelectList(_context.Tecnicos, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public TecnicoSolicitud TecnicoSolicitud { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TecnicoSolicitudes.Add(TecnicoSolicitud);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}