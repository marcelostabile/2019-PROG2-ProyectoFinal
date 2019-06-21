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
        /// La clase Proyecto define un proyecto y tiene un contener 
        /// para todas las solicitudes que pertenecen al mismo.
        /// Un proyecto puede tener 'ene' solicitudes.
        /// Cada solicitud corresponde a un rol técnico requerido por el cliente.
        /// </summary>
        /// <param name="nombre">Nombre del proyecto.</param>
        /// <param name="descripcion">Descripción del proyecto.</param>
        public Proyecto(string nombre, string descripcion) 
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Status = true;

            this.ListaSolicitudes = new List<Solicitud>();
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
        private string Nombre;
        public string nombre  
        { 
            get => this.Nombre; 
            set => this.Nombre = value;
        }

        /// <summary>
        /// Descripción del proyecto.
        /// </summary>
        private string Descripcion;
        public string descripcion  
        { 
            get => this.Descripcion; 
            set => this.Descripcion = value;
        }

        /// <summary>
        /// Estado del proyecto.
        /// 
        /// 1: Activo / 2: Cerrado.
        /// </summary>
        private bool Status;
        public bool status 
        {
            get => this.Status;
            protected set {}
        }

        /// <summary>
        /// Este método agrega una nueva solicitud a la lista de solicitudes del proyecto.
        /// </summary>
        /// <param name="SolicitudNueva">Nueva solicitud que se agrega a la lista.</param>
        public void AgregarSolicitud(Solicitud SolicitudNueva) 
        {
            this.ListaSolicitudes.Add(SolicitudNueva);
        }

        /// <summary>
        /// Este método elimina una solicitud de la lista.
        /// </summary>
        /// <param name="EliminarSolicitud">Solicitud que desea eliminar.</param>
        public void EliminarSolicitud(Solicitud EliminarSolicitud) 
        {
            this.ListaSolicitudes.Remove(EliminarSolicitud);
        }

        /// <summary>
        /// Este método retorna el costo total del proyecto.
        /// 
        /// Proyecto es la clase más apropiada para calcular su costo, 
        /// ya que contiene una lista de las solicitudes. 
        /// Cada solicitud conoce el costo de si misma.
        /// </summary>
        public int InformarCostoTotalProyecto() 
        {
            int CostoTotalProyecto = 0;
            
            foreach (Solicitud solicitud in this.ListaSolicitudes) 
            {
                CostoTotalProyecto += solicitud.costoSolicitud;
            }
            
            return CostoTotalProyecto;
        }

        /// <summary>
        /// Métodos para cambiar el status.
        /// Activar(): si el proyecto está 'Cerrado' se cambia para 'Activo'.
        /// Cerrar(): si el proyecto está 'Activo' se cambia para 'Cerrado'.
        /// </summary>
        public void Activar() 
        {
            if (this.Status == false) this.CambiarStatus();
        }

        public void Cerrar() 
        {
            if (this.Status == true) 
            {
                this.CambiarStatus();

                /// Cuando cerramos el proyecto, se cierran todas sus solicitudes.
                foreach (Solicitud solicitud in this.ListaSolicitudes)
                {
                    solicitud.Cerrar();
                }
            }
        }

        private void CambiarStatus() 
        {
            this.Status = !this.Status;
        }

    }
}
