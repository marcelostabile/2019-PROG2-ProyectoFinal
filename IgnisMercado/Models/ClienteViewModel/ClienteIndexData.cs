    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IgnisMercado.Models.ClienteViewModels
{
    public class ClienteIndexData
    {
        public IEnumerable<Cliente> Clientes { get; set; }

        public IEnumerable<Proyecto> Proyectos { get; set; }

        public IEnumerable<Solicitud> Solicitudes { get; set; }

    }
}
