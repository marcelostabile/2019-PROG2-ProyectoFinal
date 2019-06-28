using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using IgnisMercado.Models;
using IgnisMercado.Areas.Identity.Data;
using IgnisMercado.Models.ClienteViewModels;

namespace IgnisMercado.Pages.Proyectos
{
    public class IndexModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public IndexModel(IgnisMercado.Models.ApplicationContext context)
        {
            _context = context;
        }

        public ClienteIndexData ClienteIdxData  { get; set; }

        //public IList<Cliente> Cliente { get;set; }

        public async Task OnGetAsync(string id)
        {
            ClienteIdxData = new ClienteIndexData();

            // Seleccionar un usuario, mostrar proyectos.
            ClienteIdxData.Proyectos = await _context.Proyectos
                .OrderBy(p => p.Nombre)
                    .ToListAsync();

            // Seleccionar un proyecto, mostrar solicitudes.
            if (id != null)
            {
                ClienteIdxData.Solicitudes = await _context.Solicitudes
                        //.Include(p => p.RelacionClienteProyecto.Where(r => r.ClienteId == id))
                    .OrderBy(s => s.RolRequerido)
                    .OrderByDescending(s => s.NivelExperiencia)
                        .ToListAsync();
            };

            // ClienteIdxData.Usuarios = await _context.Users
            //     .OrderBy(u => u.Name)
            //     .OrderBy(u => u.Role)
            //         .ToListAsync();

            // var Cli = from c in ClienteIdxData.Usuarios 
            //     select c;

        }
    }
}
