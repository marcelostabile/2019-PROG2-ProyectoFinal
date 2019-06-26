using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IgnisMercado.Models;

namespace IgnisMercado.Pages.RelacionClienteProyectos
{
    public class IndexModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public IndexModel(IgnisMercado.Models.ApplicationContext context)
        {
            _context = context;
        }

        public IList<RelacionClienteProyecto> RelacionClienteProyecto { get;set; }

        public async Task OnGetAsync()
        {
            RelacionClienteProyecto = await _context.RelacionClienteProyectos
                .Include(r => r.Cliente)
                .Include(r => r.Proyecto).ToListAsync();
        }
    }
}
