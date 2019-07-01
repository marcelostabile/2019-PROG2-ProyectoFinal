using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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

        public int SolicitudId { get;set; }

        public SolicitudIndexData SolicitudIdx = new SolicitudIndexData();

        public async Task OnGetAsync()
        {
            SolicitudIdx.Solicitudes = await _context.Solicitudes 
                            .Include(s => s.RelacionTecnicoSolicitud)
                                .ThenInclude(r => r.Tecnico)
                                    .OrderBy(s => s.RolRequerido)
                                    .OrderByDescending(s => s.NivelExperiencia)
                                        .AsNoTracking()
                                        .ToListAsync();
        }
    }
}
