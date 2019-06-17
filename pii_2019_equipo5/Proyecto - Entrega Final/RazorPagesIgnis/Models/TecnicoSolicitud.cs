using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesIgnis
{   
    public class TecnicoSolicitud 
    { 
        public TecnicoSolicitud(int TecnicoID, int SolicitudID)
        {
            this.tecnicoID = TecnicoID;
            this.solicitudID = SolicitudID;
        }

        public TecnicoSolicitud()
        {
        }

        [Key]
        public int tecnicoID { get; set; }

        [Key]
        public int solicitudID { get; set; }

        [Required]
        public Tecnico Tecnico { get; set; }

        [Required]
        public Solicitud Solicitud { get; set; }

    }
}