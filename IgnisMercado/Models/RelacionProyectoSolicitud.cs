using System.ComponentModel.DataAnnotations;

namespace IgnisMercado.Models
{
    /// <summary>
    /// Relación Proyecto:Solicitudes.
    /// </summary>
    public class RelacionProyectoSolicitud
    {
        [Key]
        public int ProyectoId { get; set; }

        [Required]
        public Proyecto Proyecto { get; set; }

        [Key]
        public int SolicitudId { get; set; }
        
        [Required]
        public Solicitud Solicitud { get; set; }
    }     
}