namespace RazorPagesIgnis 
{
    /// <summary>
    /// Implementada por la clase Usuarios.
    /// </summary>
    public interface IUsuariosTecnicos
    {
        void AgregarTecnico(Tecnico TecnicoNuevo);

        void EliminarTecnico(Tecnico TecnicoEliminar);
    }
}