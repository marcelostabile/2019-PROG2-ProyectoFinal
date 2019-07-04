
// revisado
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using IgnisMercado.Areas.Identity.Data;
using IgnisMercado.Models;
using IgnisMercado.Models.ViewModels;

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

        public int? ProyectoId { get; set; }

        public ClienteIndexData ClienteIdxData = new ClienteIndexData();

        public async Task OnGetAsync(string id, int proyId)
        { 
            
            if (id == null)
            {
                // Se muestran todos los usuarios en pantalla.
                ClienteIdxData.Usuarios = await _context.Users
                    .Include(u => u.RelacionClienteProyecto)
                        .ThenInclude(rcp => rcp.Proyecto)
                            .OrderBy(u => u.Name)
                            .OrderBy(u => u.Role)
                                .AsNoTracking()
                                .ToListAsync();
            }
            else 
            {
                // Se muestra el usuario seleccionado (id != null).
                ClienteId = id;

                ClienteIdxData.Usuarios = await _context.Users
                    .Where(u => u.Id == id)
                    .Include(u => u.RelacionClienteProyecto)
                        .ThenInclude(rcp => rcp.Proyecto)
                            .ThenInclude(p => p.RelacionProyectoSolicitud)  
                                .ThenInclude(rps => rps.Solicitud)
                                    .AsNoTracking()
                                    .ToListAsync();

                // Instanciamos el usuario seleccionado.
                ApplicationUser usuario = ClienteIdxData.Usuarios
                                            .Where(u => u.Id == id).Single();

                // Seleccionamos los proyectos del usuario.
                ClienteIdxData.Proyectos = usuario.RelacionClienteProyecto 
                                            .Select(r => r.Proyecto).ToList();

                if (proyId != 0) 
                { 
                    // El usuario selecciona un proyecto del cliente.
                    ProyectoId = proyId;

                    // Seleccionamos el proyecto del cliente.
                    Proyecto proyecto = ClienteIdxData.Proyectos
                                            .Where(p => p.ProyectoId == proyId).Single();

                    // Seleccionamos las solicitudes del proyecto.
                    ClienteIdxData.Solicitudes = proyecto.RelacionProyectoSolicitud
                                                    .Select(rps => rps.Solicitud).ToList();

                };

            };

        }
    }
}
