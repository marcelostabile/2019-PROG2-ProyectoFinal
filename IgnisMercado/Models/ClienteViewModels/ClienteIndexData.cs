using System.Collections.Generic;

namespace IgnisMercado.Models.ClienteViewModels
{
    public class ClienteIndexData
    {
        public IEnumerable<Cliente> Clientes { get; set; }

        public IEnumerable<Proyecto> Proyectos { get; set; }

        public IEnumerable<Solicitud> Solicitudes { get; set; }

    }
}
