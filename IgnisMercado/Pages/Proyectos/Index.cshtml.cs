using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IgnisMercado.Models;

namespace IgnisMercado.Pages.Proyectos
{
    public class IndexModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public IndexModel(IgnisMercado.Models.ApplicationContext context)
        {
            _context = context;
        }

        public IList<Proyecto> Proyecto { get;set; }

        public IList<Cliente> Cliente { get;set; }

        public async Task OnGetAsync()
        {
            Proyecto = await _context.Proyectos.ToListAsync();

            Cliente = await _context.Clientes.ToListAsync();

            var Cli = from c in Cliente select c; 
        }
    }
}
