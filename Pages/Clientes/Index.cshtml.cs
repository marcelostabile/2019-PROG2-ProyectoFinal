using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using IgnisMercado.Models;
using IgnisMercado.Models.ClienteViewModels;

namespace IgnisMercado.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public IndexModel(IgnisMercado.Models.ApplicationContext context)
        {
            _context = context;
        }

        // public IList<Cliente> Cliente { get;set; }

        public ClienteIndexData Cliente { get;set; }

        public int ClienteId { get; set; }

        public int ProyectoId { get; set; }

        public async Task OnGetAsync(int? id, int? proyectoId)
        {
            // Cliente = await _context.Clientes.ToListAsync();

            Cliente = new ClienteIndexData();

            Cliente.Clientes = await _context.Clientes
		        .Include(c => c.ListaProyectos)
                    .ThenInclude(c => c.ListaSolicitudes)
                        .AsNoTracking()
                        .ToListAsync();

            if (id != null)
            {
                ClienteId = id.Value;

                Cliente cliente = Cliente.Clientes.Where(m => m.Id == id.Value).Single();

                //Cliente.Proyectos = cliente.ListaProyectos.Select(a => a.ListaSolicitudes);
            }

            if (proyectoId != null)
            {
                ProyectoId = id.Value;
            }

        }
    }
}
