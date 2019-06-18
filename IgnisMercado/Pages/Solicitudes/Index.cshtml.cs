using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IgnisMercado;
using IgnisMercado.Data;

namespace IgnisMercado.Pages.Solicitudes
{
    public class IndexModel : PageModel
    {
        private readonly IgnisMercado.Data.ApplicationDbContext _context;

        public IndexModel(IgnisMercado.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Solicitud> Solicitud { get;set; }

        public async Task OnGetAsync()
        {
            Solicitud = await _context.Solicitud.ToListAsync();
        }
    }
}
