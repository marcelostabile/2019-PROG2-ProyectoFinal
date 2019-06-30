using System.Collections.Generic;
using IgnisMercado.Areas.Identity.Data;

namespace IgnisMercado.Models.ClienteViewModels
{
    public class ClienteIndexData
    {
        public IList<ApplicationUser> Usuarios { get; set; }

        public IList<Proyecto> Proyectos { get; set; }

        public IList<Solicitud> Solicitudes { get; set; }

    }
}
