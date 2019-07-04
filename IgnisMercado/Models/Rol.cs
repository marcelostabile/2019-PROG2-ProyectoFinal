using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IgnisMercado.Models 
{
    public class Rol
    {
        /// <summary>
        /// Constructor sin argumentos para Razorpages.
        /// </summary>
        public Rol() 
        {
        }

        /// <summary>
        /// Relación Tecnico:Rol.
        /// </summary>
        [Key]
        public int RolId { get; set; } 

        /// <summary>
        /// Relación Tecnico:Rol.
        /// </summary>
        public IList<RelacionTecnicoRol> RelacionTecnicoRol { get; set; }

        /// Nombre del rol.
        [Required]
        [Display(Name = "Nivel")]
        public string Nivel { get; set; }

        /// Descripción del rol.
        [StringLength(300)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

    }    
}
