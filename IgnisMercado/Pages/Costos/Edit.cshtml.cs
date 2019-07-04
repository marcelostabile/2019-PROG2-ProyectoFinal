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

        public CostoViewModel CostoView = new CostoViewModel();

        [BindProperty]
        public Costo Costo { get; set; }
        
        // [BindProperty]
        public Costo costoInstancia = Costo.obtenerInstancia();

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
            //Costo costoInstancia = Costo.obtenerInstancia();

            _context.Attach(CostoView).State = EntityState.Modified;

            costoInstancia.ModificarPrimeraHoraBasico(Costo.PrimeraHoraBasico);
            costoInstancia.ModificarCostoHoraBasico(Costo.CostoHoraBasico);
            costoInstancia.ModificarJornadaBasico(Costo.JornadaBasico);

            costoInstancia.ModificarPrimeraHoraAvanzado(Costo.PrimeraHoraAvanzado);
            costoInstancia.ModificarCostoHoraAvanzado(Costo.CostoHoraAvanzado);
            costoInstancia.ModificarJornadaAvanzado(Costo.JornadaAvanzado);

            costoInstancia.ModificarHoraJornada(Costo.HoraJornada);

            costoInstancia.Notificar();

            // costoInstancia.ModificarPrimeraHoraBasico(Costo.PrimeraHoraBasico);
            // costoInstancia.ModificarCostoHoraBasico(Costo.CostoHoraBasico);
            // costoInstancia.ModificarJornadaBasico(Costo.JornadaBasico);

            // costoInstancia.ModificarPrimeraHoraAvanzado(Costo.PrimeraHoraAvanzado);
            // costoInstancia.ModificarCostoHoraAvanzado(Costo.CostoHoraAvanzado);
            // costoInstancia.ModificarJornadaAvanzado(Costo.JornadaAvanzado);

            // costoInstancia.ModificarHoraJornada(Costo.HoraJornada);

            // costoInstancia.Notificar();

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
