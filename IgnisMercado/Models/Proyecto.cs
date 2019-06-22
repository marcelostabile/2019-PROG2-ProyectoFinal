using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IgnisMercado.Models 
{   
    public class Proyecto : IGestionSolicitudes, ICostoProyecto
    { 
        /// <summary>
        /// Para RazorPages: constructor sin argumentos.
        /// </summary>
        public Proyecto() 
        {
        }

        /// <summary>
        /// Para RazorPages: atributo PrimaryKey de la tabla.
        /// </summary>
        public int Id { get; set; } 

        /// <summary>
        /// La clase Proyecto define un proyecto y contiene todas las solicitudes asociadas al proyecto.
        /// Un proyecto puede tener 'ene' solicitudes.
        /// Cada solicitud corresponde a un rol técnico requerido por el cliente.
        /// </summary>
        public Proyecto(string nombre, string descripcion) 
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Status = true;
        }

        /// <summary>
        /// Relación Cliente:Proyectos (uno-a-muchos)
        /// </summary>
        public virtual Cliente Cliente { get; set; }

        /// <summary>
        /// Lista de Solicitudes del proyecto.
        /// 
        /// Relación Proyecto:Solicitudes (uno-a-muchos)
        /// </summary>
        public IList<Solicitud> ListaSolicitudes { get; private set; }

        /// <summary>
        /// Nombre del proyecto.
        /// </summary>
        [Display(Name = "Título")]
        public string Nombre { get; set; }

        /// <summary>
        /// Descripción del proyecto.
        /// </summary>
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Estado del proyecto.
        /// </summary>
        [Display(Name = "Status")]
        public bool Status { get; protected set; }

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

            /// Cuando cerramos el proyecto, se cierran todas sus solicitudes.
            if (this.ListaSolicitudes.Count > 0) 
            {
                foreach (Solicitud solicitud in this.ListaSolicitudes) solicitud.StatusInactivo();
            }
        }

        /// <summary>
        /// Este método agrega una nueva solicitud a la lista de solicitudes del proyecto.
        /// </summary>
        public void AgregarSolicitud(Solicitud SolicitudNueva) 
        {
            this.ListaSolicitudes.Add(SolicitudNueva);
        }

        /// <summary>
        /// Este método elimina una solicitud de la lista.
        /// </summary>
        public void EliminarSolicitud(Solicitud EliminarSolicitud) 
        {
            this.ListaSolicitudes.Remove(EliminarSolicitud);
        }

        /// <summary>
        /// Este método retorna el costo total del proyecto.
        /// </summary>
        public int InformarCostoTotalProyecto() 
        {
            int CostoTotalProyecto = 0;
            
            foreach (Solicitud solicitud in this.ListaSolicitudes) 
            {
                CostoTotalProyecto += solicitud.CostoSolicitud;
            }
            
            return CostoTotalProyecto;
        }

    }
}
