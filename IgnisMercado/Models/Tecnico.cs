using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using IgnisMercado.Areas.Identity.Data;

namespace IgnisMercado.Models
{   
    public class Tecnico : ApplicationUser
    { 
        /// <summary>
        /// Constructor sin argumentos para Razorpages.
        /// </summary>
        public Tecnico() 
        {
        }

        /// <summary>
        ///  Id del técnico.
        /// </summary>
        [Key]
        public string TecnicoId 
        {
            get 
            { 
                return this.Id;
            }
        }

        // /// <summary>
        // /// Relación Tecnico:Solicitud.
        // /// </summary>
        // public IList<RelacionTecnicoSolicitud> RelacionTecnicoSolicitudes { get; set; }

        // /// <summary>
        // /// Relación Tecnico:Rol.
        // /// </summary>
        // public IList<RelacionTecnicoRol> RelacionTecnicoRoles { get; set; }

        /// <summary>
        /// Presentación
        /// El técnico puede incluir un texto para aclarar cosas, describir su forma de trabajo o intéreses.
        /// </summary>
        [StringLength(300)]
        [Display(Name = "Presentación")]
        private string Presentacion { get; set; }

        /// <summary>
        /// Nivel de Experiencia que el técnico se adjudica de experiencia.
        /// </summary>
        /// <value>"Básico", "Avanzado"</value>
        [Display(Name = "Nivel Experiencia")]
        public string NivelExperiencia { get; set; }

        /// <summary>
        /// Método para cambiar el nivel de experiencia a Básico.
        /// </summary>
        public void CambiarNivelExperienciaBasico()
        {
            this.NivelExperiencia = "Básico";
        }

        /// <summary>
        /// Método para cambiar el nivel de experiencia a Avanzado.
        /// </summary>
        public void CambiarNivelExperienciaAvanzado()
        {
            this.NivelExperiencia = "Avanzado";
        }

    }
}
