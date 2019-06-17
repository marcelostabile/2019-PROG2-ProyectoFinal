using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesIgnis;
using RazorPagesIgnis.Models;

namespace RazorPagesIgnis.Pages.tecnicos
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
            return Page();
        }

        [BindProperty]
        public Tecnico Tecnico { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tecnicos.Add(Tecnico);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}