using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using IgnisMercado.Models;
using IgnisMercado.Areas.Identity.Data;
using IgnisMercado.Models.ClienteViewModels;

namespace IgnisMercado.Pages.Usuarios
{
    public class IndexModel : PageModel
    {
        private readonly IgnisMercado.Models.ApplicationContext _context;

        public IndexModel(IgnisMercado.Models.ApplicationContext context)
        {
            _context = context;
        }

        public string ClienteId { get; set; }

        public int ProyectoId { get; set; }

        public int SolicitudId { get; set; }

        public ClienteIndexData ClienteIdxData  { get; set; }

        public async Task OnGetAsync(string id, int? proyectoId)
        { 
            ClienteIdxData = new ClienteIndexData();

            // Mostrar los usuarios.
            ClienteIdxData.Usuarios = await _context.Users
                .OrderBy(u => u.Name)
                .OrderBy(u => u.Role)
                    .ToListAsync();

            // Seleccionar un usuario, mostrar proyectos.
            if (id != null)
            {
                ClienteIdxData.Proyectos = await _context.Proyectos
                //.Include(p => p.RelacionClienteProyecto.Where(r => r.ClienteId == id))
                    .OrderBy(p => p.Nombre)
                        .ToListAsync();
            };

            // Seleccionar un proyecto, mostrar solicitudes.
            if (proyectoId != null)
            {
                ClienteIdxData.Solicitudes = await _context.Solicitudes
                        //.Include(p => p.RelacionClienteProyecto.Where(r => r.ClienteId == id))
                    .ToListAsync();
            };

        }
    }
}

//     // ClienteIdxData.Clientes = await _context.Users
//     //         .Include(c => c.RelacionClienteProyecto.Select(r => r.ClienteId == appUser.Id))
//     //             .ThenInclude(p => p.Proyecto)
//     //                 .OrderBy(u => u.Name)
//     //                 .OrderBy(u => u.Role)
//     //                     .AsNoTracking()
//     //                     .ToListAsync();
