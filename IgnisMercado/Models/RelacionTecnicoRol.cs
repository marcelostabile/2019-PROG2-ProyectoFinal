using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IgnisMercado.Models
{
    /// <summary>
    /// Relación Tecnico:Rol.
    /// </summary>
    public class RelacionTecnicoRol
    {
        public string TecnicoId { get; set; }
        public Tecnico Tecnico { get; set; }

        public int RolId { get; set; }
        public Rol Rol { get; set; }

    }     
}