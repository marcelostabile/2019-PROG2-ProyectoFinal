using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using IgnisMercado.Areas.Identity.Data;

namespace IgnisMercado.Models
{ 
    public class Cliente
    { 
        /// <summary>
        /// Constructor sin argumentos para Razorpages.
        /// </summary>
        public Cliente() 
        {
        }

        /// <summary>
        /// Relación Cliente:Proyectos.
        /// </summary>
        [Key]
        public string ClienteId { get; set; }

        /// <summary>
        /// Relación Cliente:Proyectos.
        /// </summary>
        public IList<RelacionClienteProyecto> RelacionClienteProyecto { get; set; }

    }
}
