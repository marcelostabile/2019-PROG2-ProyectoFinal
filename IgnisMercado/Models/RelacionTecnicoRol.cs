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
        public int Id { get; set; }

        [ForeignKey("Tecnico")]
        public string TecnicoId { get; set; }
        public Tecnico Tecnico { get; set; }

        [ForeignKey("Rol")]
        public int RolId { get; set; }
        public Rol Rol { get; set; }

    }     
}