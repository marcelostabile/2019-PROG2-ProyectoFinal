using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using IgnisMercado.Models;
using IgnisMercado.Models.ViewModels;

namespace IgnisMercado.Pages.Costos
{
    public class EditModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public EditModel(IgnisMercado.Models.ApplicationContext context)
        {
            _context = context;
        }

        public EditModel()
        {
        }

        CostoViewModel CostoView { get; set; }

        [BindProperty]
        public Costo Costo { get; set; }

        Costo costoInstancia = Costo.obtenerInstancia();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Costo = await _context.Costos.FirstOrDefaultAsync(m => m.Id == id);

            if (Costo == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {            
            Costo costoInstancia = Costo.obtenerInstancia();

            costoInstancia.ModificarPrimeraHoraBasico(CostoView.PrimeraHoraBasico);
            costoInstancia.ModificarCostoHoraBasico(CostoView.CostoHoraBasico);
            costoInstancia.ModificarJornadaBasico(CostoView.JornadaBasico);

            costoInstancia.ModificarPrimeraHoraAvanzado(CostoView.PrimeraHoraAvanzado);
            costoInstancia.ModificarCostoHoraAvanzado(CostoView.CostoHoraAvanzado);
            costoInstancia.ModificarJornadaAvanzado(CostoView.JornadaAvanzado);

            costoInstancia.ModificarHoraJornada(CostoView.HoraJornada);

            costoInstancia.Notificar();

            // foreach (Solicitud sol in _context.Solicitudes)
            // {
            //     sol.ActualizarCostoSolicitudActiva();
            // }

            // Se guarda la actualizacion de precios en las solicitu des.
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
