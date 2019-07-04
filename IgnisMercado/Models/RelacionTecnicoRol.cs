using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using IgnisMercado.Areas.Identity.Data;

namespace IgnisMercado.Models
{
    /// <summary>
    /// Relación Tecnico:Rol.
    /// </summary>
    public class RelacionTecnicoRol
    { 
        [Key]
        public string TecnicoId { get; set; }

        [Required]
        public ApplicationUser Tecnico { get; set; }

        [Key]
        public int RolId { get; set; }
        
        [Required]
        public Rol Rol { get; set; }

    }     
}