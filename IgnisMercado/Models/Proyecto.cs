using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IgnisMercado.Models 
{ 
    public class Proyecto //: IGestionSolicitudes, ICostoProyecto
    { 
        /// <summary>
        /// Constructor sin argumentos para Razorpages.
        /// </summary>
        public Proyecto() 
        {
        }

        /// <summary>
        /// La clase Proyecto contiene todas las solicitudes asociadas al proyecto.
        /// Un proyecto puede tener 'ene' solicitudes y cada solicitud corresponde 
        /// a una necesidad de un técnico.
        /// </summary>
        public Proyecto(string nombre, string descripcion, bool status) 
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Status = status;
        }

        /// <summary>
        /// Relación Cliente:Proyectos y Proyecto:Solicitudes.
        /// </summary>
        [Key]
        public int ProyectoId { get; set; }

        /// <summary>
        /// Relación Cliente:Proyectos.
        /// </summary>
        public IList<RelacionClienteProyecto> RelacionClienteProyecto { get; set; }

        /// <summary>
        /// Relación Proyecto:Solicitudes.
        /// </summary>
        public IList<RelacionProyectoSolicitud> RelacionProyectoSolicitud { get; set; }

        /// <summary>
        /// Nombre del proyecto.
        /// </summary>
        [Required]
        [Display(Name = "Título")]
        public string Nombre { get; set; }

        /// <summary>
        /// Descripción del proyecto.
        /// </summary>
        [Required]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Estado del proyecto.
        /// </summary>
        [Display(Name = "Status")]
        public bool Status { get; set; }

        /// <summary>
        /// Métodos para cambiar el status.
        /// </summary>
        public void StatusActivo() 
        {
            this.Status = true;
        }

        public void StatusInactivo() 
        {
            this.Status = false;

            // /// Cuando cerramos el proyecto, se cierran todas sus solicitudes.
            // if (this.ListaSolicitudes.Count > 0) 
            // {
            //     foreach (Solicitud solicitud in this.ListaSolicitudes) solicitud.StatusInactivo();
            // }
        }

    }
}
