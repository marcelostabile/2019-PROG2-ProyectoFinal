using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IgnisMercado;
using IgnisMercado.Data;

namespace IgnisMercado.Pages.Proyectos
{
    public class IndexModel : PageModel
    {
        private readonly IgnisMercado.Data.ApplicationDbContext _context;

        public IndexModel(IgnisMercado.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Proyecto> Proyecto { get;set; }

        public async Task OnGetAsync()
        {
            Proyecto = await _context.Proyecto.ToListAsync();
        }
    }
}
