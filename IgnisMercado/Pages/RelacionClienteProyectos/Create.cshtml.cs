using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IgnisMercado.Models;

namespace IgnisMercado.Pages.RelacionClienteProyectos
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
        ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Id");
        ViewData["ProyectoId"] = new SelectList(_context.Proyectos, "ProyectoId", "Descripcion");
            return Page();
        }

        [BindProperty]
        public RelacionClienteProyecto RelacionClienteProyecto { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RelacionClienteProyectos.Add(RelacionClienteProyecto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}