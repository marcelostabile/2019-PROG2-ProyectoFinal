using System;
using System.ComponentModel.DataAnnotations;

namespace IgnisMercado.Models 
{
    public class Rol : IRol
    {
        /// <summary>
        /// Para RazorPages: constructor sin argumentos.
        /// </summary>
        public Rol() 
        {
        }

        /// <summary>
        /// Para RazorPages: atributo PrimaryKey de la tabla.
        /// </summary>
        public int Id { get; set; } 

        /// Nombre del rol.
        [Display(Name = "Nombre")]
        public string Nombre { get; protected set; }

        /// Descripción del rol.
        [Display(Name = "Descripción")]
        public string Descripcion { get; protected set; }

        /// Modificar nombre del rol.
        public void ModificarNombre(string nombre) 
        {
            this.Nombre = nombre;
        }

        // Modificar descripción del rol.
        public void ModificarDescripcion(string descripcion) 
        {
            this.Descripcion = descripcion;
        }

    }    
}
