using System.ComponentModel.DataAnnotations;

namespace IgnisMercado.Models 
{
    public class Rol
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
        [Display(Name = "Nivel")]
        public string Nivel { get; set; }

        /// Descripción del rol.
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

    }    
}
