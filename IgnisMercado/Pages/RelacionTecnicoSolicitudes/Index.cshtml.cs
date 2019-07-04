using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IgnisMercado.Models;

namespace IgnisMercado.Pages.RelacionTecnicoSolicitudes
{
    public class IndexModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public IndexModel(IgnisMercado.Models.ApplicationContext context)
        {
            _context = context;
        }

        public IList<RelacionTecnicoSolicitud> RelacionTecnicoSolicitud { get;set; }

        public async Task OnGetAsync()
        {
            RelacionTecnicoSolicitud = await _context.RelacionTecnicoSolicitudes
                .Include(r => r.Solicitud)
                .Include(r => r.Tecnico).ToListAsync();
        }
    }
}
