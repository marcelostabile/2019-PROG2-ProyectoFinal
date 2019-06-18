using System.Collections.Generic;

namespace IgnisMercado 
{ 
    public class ListaRol : IListaRol
    {
        /// <summary>
        /// Esta clase conoce la lista de roles.
        /// </summary>
        public ListaRol()  
        {   
            this.ListaDeRoles = new List<Rol>();
        } 

        // Roles.
        private List<Rol> ListaDeRoles;
        public List<Rol> listaDeroles 
        {
            get => this.ListaDeRoles;
            protected set {}
        }

        // Método para agregar un nuevo rol a la lista.
        public void AgregarRol(Rol RolNuevo)
        {
            ListaDeRoles.Add(RolNuevo);
        }

        // Método para eliminar un rol de la lista.
        public void EliminarRol(Rol EliminarRol)
        {
            ListaDeRoles.Remove(EliminarRol);
        }

    }
}
