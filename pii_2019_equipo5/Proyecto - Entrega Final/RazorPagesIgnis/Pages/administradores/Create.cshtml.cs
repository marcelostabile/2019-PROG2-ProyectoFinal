using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesIgnis;
using RazorPagesIgnis.Models;

namespace RazorPagesIgnis.Pages.administradores
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
        public Administrador Administrador { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Administradores.Add(Administrador);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}