using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


using IgnisMercado.Areas.Identity.Data;
using IgnisMercado.Models;
using IgnisMercado.Models.ViewModels;

namespace IgnisMercado.Pages.Solicitudes
{
    public class IndexModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public IndexModel(IgnisMercado.Models.ApplicationContext context)
        {
            _context = context;
        }

        public Solicitud Solicitud { get; set; }

        public int? SolicitudId { get;set; }

        public string TecnicoId { get;set; }

        public SolicitudIndexData SolicitudIdx = new SolicitudIndexData();

        public IEnumerable<ApplicationUser> TecnicosAsignados { get; set; }

        public IEnumerable<ApplicationUser> TecnicosDisponibles { get; set; }

        public async Task OnGetAsync(int? id)
        { 
            if (id == null)
            {
                SolicitudIdx.Solicitudes = await _context.Solicitudes 
                    .Include(s => s.RelacionTecnicoSolicitud)
                        .ThenInclude(r => r.Tecnico)
                            .OrderBy(s => s.RolRequerido)
                            .OrderByDescending(s => s.NivelExperiencia)
                                .AsNoTracking()
                                .ToListAsync();

            }
            else    
            {
                SolicitudId = id;

                // Cuando se selecciona una solicitud, mostramos solo la solicitud seleccionada.
                SolicitudIdx.Solicitudes = await _context.Solicitudes 
                    .Where(s => s.SolicitudId == id)
                    .Include(s => s.RelacionTecnicoSolicitud)
                        .ThenInclude(r => r.Tecnico)
                            .OrderBy(s => s.RolRequerido)
                            .OrderByDescending(s => s.NivelExperiencia)
                                .AsNoTracking()
                                .ToListAsync();

                Solicitud solicitud = SolicitudIdx.Solicitudes 
                                        .Where(s => s.SolicitudId == id).Single();

                this.TecnicosAsignados = solicitud.RelacionTecnicoSolicitud 
                                            .Select(r => r.Tecnico);
                                            
                this.TecnicosDisponibles = await _context.Tecnicos
                                                .Where(t => !TecnicosAsignados.Contains(t))
                                                .ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {

        //     if (!ModelState.IsValid)
        //     {
        //         return Page();
        //     }

            var solicitudActualizar = await _context.Movies
                .Include(l => l.Location)
                .Include(a => a.Appeareances)
                    .ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(m => m.ID == id);

 
        //     if (await TryUpdateModelAsync<Movie>(
        //         movieToUpdate,
        //         "Movie",
        //         i => i.Title, i => i.ReleaseDate,
        //         i => i.Price, i => i.Genre,
        //         i => i.Location))
        //     {
        //         if (String.IsNullOrWhiteSpace(movieToUpdate.Location?.Name))
        //         {
        //             movieToUpdate.Location = null;
        //         }

        //         try
        //         {
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!MovieExists(Movie.ID))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //     }
        //     return RedirectToPage("./Index");
        // }

        // public async Task<IActionResult> OnPostDeleteActorAsync(int id, int actorToDeleteID)
        // {
        //     Movie movieToUpdate = await _context.Movies
        //         .Include(l => l.Location)
        //         .Include(a => a.Appeareances)
        //             .ThenInclude(a => a.Actor)
        //         .FirstOrDefaultAsync(m => m.ID == id);

        //     await TryUpdateModelAsync<Movie>(movieToUpdate);

        //     var actorToDelete = movieToUpdate.Appeareances.Where(a => a.ActorID == actorToDeleteID).FirstOrDefault();
        //     if (actorToDelete != null)
        //     {
        //         movieToUpdate.Appeareances.Remove(actorToDelete);
        //     }

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!MovieExists(Movie.ID))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return Redirect(Request.Path + $"?id={id}");
        // }

        // public async Task<IActionResult> OnPostAddActorAsync(int? id, int? actorToAddID)
        // {
        //     Movie movieToUpdate = await _context.Movies
        //         .Include(a => a.Appeareances)
        //             .ThenInclude(a => a.Actor)
        //         .FirstOrDefaultAsync(m => m.ID == Movie.ID);

        //     await TryUpdateModelAsync<Movie>(movieToUpdate);


        //     if (actorToAddID != null)
        //     {
        //         Actor actorToAdd = await _context.Actors.Where(a => a.ID == actorToAddID).FirstOrDefaultAsync();
        //         if (actorToAdd != null)
        //         {
        //             var appereanceToAdd = new Appereance() {
        //                 ActorID = actorToAddID.Value,
        //                 Actor = actorToAdd,
        //                 MovieID = movieToUpdate.ID,
        //                 Movie = movieToUpdate };
        //             movieToUpdate.Appeareances.Add(appereanceToAdd);
        //         }
        //     }

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!MovieExists(Movie.ID))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return Redirect(Request.Path + $"?id={id}");
        // }

        // private bool MovieExists(int id)
        // {
        //     return _context.Movies.Any(e => e.ID == id);
        // }

        }
    }

