using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IgnisMercado.Models;

namespace IgnisMercado.Pages.RelacionProyectoSolicitudes
{
    public class IndexModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public IndexModel(IgnisMercado.Models.ApplicationContext context)
        {
            _context = context;
        }

        public IList<RelacionProyectoSolicitud> RelacionProyectoSolicitud { get;set; }

        public async Task OnGetAsync()
        {
            RelacionProyectoSolicitud = await _context.RelacionProyectoSolicitudes
                .Include(r => r.Proyecto)
                .Include(r => r.Solicitud).ToListAsync();
        }
    }
}
