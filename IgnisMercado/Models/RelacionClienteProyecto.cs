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
        public int Id { get; set; }

        [ForeignKey("Cliente")]
        public string ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [ForeignKey("Proyecto")]
        public int ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; }

    }     
}