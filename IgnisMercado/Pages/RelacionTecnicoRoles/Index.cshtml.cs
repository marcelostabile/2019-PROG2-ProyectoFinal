using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IgnisMercado.Models;

namespace IgnisMercado.Pages.RelacionTecnicoRoles
{
    public class IndexModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public IndexModel(IgnisMercado.Models.ApplicationContext context)
        {
            _context = context;
        }

        public IList<RelacionTecnicoRol> RelacionTecnicoRol { get;set; }

        public async Task OnGetAsync()
        {
            RelacionTecnicoRol = await _context.RelacionTecnicoRoles
                .Include(r => r.Rol)
                .Include(r => r.Tecnico).ToListAsync();
        }
    }
}
