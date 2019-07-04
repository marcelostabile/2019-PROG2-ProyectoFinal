using System.ComponentModel.DataAnnotations;

using IgnisMercado.Areas.Identity.Data;

namespace IgnisMercado.Models
{
    /// <summary>
    /// Relación Tecnico:Solicitud.
    /// </summary>
    public class RelacionTecnicoSolicitud
    { 
        [Key]
        public string TecnicoId { get; set; }

        [Required]
        public ApplicationUser Tecnico { get; set; }

        [Key]
        public int SolicitudId { get; set; }
        
        [Required]
        public Solicitud Solicitud { get; set; }

    }     
}