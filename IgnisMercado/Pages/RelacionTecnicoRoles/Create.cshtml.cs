using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IgnisMercado.Models;

namespace IgnisMercado.Pages.RelacionTecnicoRoles
{
    public class CreateModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public CreateModel(IgnisMercado.Models.ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RolId"] = new SelectList(_context.Roles, "RolId", "Nivel");
        ViewData["TecnicoId"] = new SelectList(_context.Tecnicos, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public RelacionTecnicoRol RelacionTecnicoRol { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RelacionTecnicoRoles.Add(RelacionTecnicoRol);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}