using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IgnisMercado;
using IgnisMercado.Data;

namespace IgnisMercado.Pages.Roles
{
    public class CreateModel : PageModel
    {
        private readonly IgnisMercado.Data.ApplicationDbContext _context;

        public CreateModel(IgnisMercado.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Rol Rol { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Rol.Add(Rol);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}