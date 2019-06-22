using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using IgnisMercado.Areas.Identity.Data;

namespace IgnisMercado.Models
{   
    public class Cliente : ApplicationUser
    {
        /// <summary>
        /// El cliente es la persona que tiene el proyecto y contrata los servicios del técnico.
        /// </summary>
        public Cliente() 
        {
        }

        /// <summary>
        ///  Lista de Proyectos del cliente.
        /// 
        /// Relación Cliente:Proyectos (uno-a-muchos)
        /// </summary>
        public IList<Proyecto> ListaProyectos { get; private set; }

        /// <summary>
        /// Este método agrega un nuevo proyecto a la lista de proyectos del cliente.
        /// </summary>
        public void AgregarProyecto(Proyecto ProyectoNuevo) 
        {
            this.ListaProyectos.Add(ProyectoNuevo);
        }

    }
}
