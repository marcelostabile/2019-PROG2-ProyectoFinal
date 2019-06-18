namespace IgnisMercado 
{
    /// <summary>
    /// Implementada por la clase Proyecto.
    /// </summary>
    public interface IGestionSolicitudes
    {
        void AgregarSolicitud(Solicitud SolicitudNueva);

        void EliminarSolicitud(Solicitud EliminarSolicitud);

    }
}
