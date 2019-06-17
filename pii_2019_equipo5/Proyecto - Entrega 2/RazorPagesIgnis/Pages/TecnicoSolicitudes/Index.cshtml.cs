using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesIgnis;
using RazorPagesIgnis.Models;

namespace RazorPagesIgnis.Pages.tecnicoSolicitudes
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesIgnis.Models.RazorPagesIgnisContext _context;

        public IndexModel(RazorPagesIgnis.Models.RazorPagesIgnisContext context)
        {
            _context = context;
        }

        public IList<TecnicoSolicitud> TecnicoSolicitud { get;set; }

        public async Task OnGetAsync()
        {
            TecnicoSolicitud = await _context.TecnicoSolicitud
                .Include(t => t.Solicitud)
                .Include(t => t.Tecnico).ToListAsync();
        }
    }
}
