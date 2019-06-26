using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IgnisMercado.Models
{
    /// <summary>
    /// Relación Proyecto:Solicitudes.
    /// </summary>
    public class RelacionProyectoSolicitud
    {
        public int Id { get; set; }

        [ForeignKey("Proyecto")]
        public int ProyectoId { get; set; }
        public Proyecto Proyecto { get; set; }

        [ForeignKey("Solicitud")]
        public int SolicitudId { get; set; }
        public Solicitud Solicitud { get; set; }
    }     
}