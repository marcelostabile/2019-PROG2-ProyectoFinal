using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IgnisMercado.Models;

namespace IgnisMercado.Pages.Roles
{
    public class IndexModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public IndexModel(IgnisMercado.Models.ApplicationContext context)
        {
            _context = context;
        }

        public IList<Rol> Rol { get;set; }

        public async Task OnGetAsync()
        {
            Rol = await _context.Roles
                    .OrderBy(r => r.Descripcion)
                    .OrderByDescending(r => r.Nivel)
                    .ToListAsync();
        }
    }
}
