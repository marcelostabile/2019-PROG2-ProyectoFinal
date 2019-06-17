using System;
using System.Collections.Generic;

namespace RazorPagesIgnis 
{   
    public class ListaRol : IListaRol
    {
        /// <summary>
        /// Esta clase conoce la lista de roles.
        /// </summary>
        public ListaRol()  
        {   
            List<Rol> ListaDeRoles = new List<Rol> {};

            this.listaDeRoles = ListaDeRoles;
        } 

        // Roles.
        private List<Rol> listaDeRoles;
        public List<Rol> ListaDeroles 
        {
            get => this.listaDeRoles;
            protected set {}
        }

        public void AgregarRol(Rol nuevoRol)
        {
            listaDeRoles.Add(nuevoRol);
        }

        public void EliminarRol(Rol eliminarRol)
        {
            listaDeRoles.Remove(eliminarRol);
        }

    }
}