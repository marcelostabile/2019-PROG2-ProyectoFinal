using System;
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

        public int ID { get; set; }

        public int tecnicoID { get; set; }

        public int solicitudID { get; set; }

        public Tecnico Tecnico { get; set; }

        public Solicitud Solicitud { get; set; }

    }
}