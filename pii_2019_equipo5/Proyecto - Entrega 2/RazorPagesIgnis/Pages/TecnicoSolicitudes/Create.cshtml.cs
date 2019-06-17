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
        private readonly RazorPagesIgnis.Models.RazorPagesIgnisContext _context;

        public CreateModel(RazorPagesIgnis.Models.RazorPagesIgnisContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["solicitudID"] = new SelectList(_context.Solicitud, "ID", "ID");
        ViewData["tecnicoID"] = new SelectList(_context.Tecnico, "ID", "ID");
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

            _context.TecnicoSolicitud.Add(TecnicoSolicitud);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}