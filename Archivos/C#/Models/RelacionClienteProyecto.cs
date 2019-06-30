using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IgnisMercado.Models
{
    /// <summary>
    /// Relación Cliente:Proyectos.
    /// </summary>
    public class RelacionClienteProyecto
    { 
        [Key]
        public string ClienteId { get; set; }

        [Required]
        public Cliente Cliente { get; set; }

        [Key]
        public int ProyectoId { get; set; }

        [Required]
        public Proyecto Proyecto { get; set; }

    }     
}