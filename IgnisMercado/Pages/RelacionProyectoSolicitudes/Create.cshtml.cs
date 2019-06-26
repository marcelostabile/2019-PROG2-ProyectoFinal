using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IgnisMercado.Models;

namespace IgnisMercado.Pages.RelacionProyectoSolicitudes
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
        ViewData["ProyectoId"] = new SelectList(_context.Proyectos, "ProyectoId", "Descripcion");
        ViewData["SolicitudId"] = new SelectList(_context.Solicitudes, "SolicitudId", "SolicitudId");
            return Page();
        }

        [BindProperty]
        public RelacionProyectoSolicitud RelacionProyectoSolicitud { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RelacionProyectoSolicitudes.Add(RelacionProyectoSolicitud);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}