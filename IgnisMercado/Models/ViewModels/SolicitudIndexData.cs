using System.Collections.Generic;
using IgnisMercado.Areas.Identity.Data;

namespace IgnisMercado.Models.ViewModels
{
    public class SolicitudIndexData
    {
        public IList<Solicitud> Solicitudes { get; set; }

        public IList<ApplicationUser> Tecnicos { get; set; }
    }
}
