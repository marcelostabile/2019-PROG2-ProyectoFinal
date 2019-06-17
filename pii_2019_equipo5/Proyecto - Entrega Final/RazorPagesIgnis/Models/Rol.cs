using System;

namespace RazorPagesIgnis 
{
    public class Rol : IRol
    {
        /// <summary>
        /// Rol del técnica.
        /// </summary>
        public Rol(string Nombre, string Descripcion) 
        {
            this.nombre = Nombre;
            this.descripcion = Descripcion;
        }

        // Nombre del rol.
        private string nombre;
        public string Nombre  
        { 
            get => this.nombre; 
            set => this.nombre = value;
        }

        // Descripción del rol (opcional).
        private string descripcion;
        public string Descripcion  
        { 
            get => this.descripcion; 
            set => this.descripcion = value;
        }
        
        // Modificar nombre del rol.
        public void ModificarNombre(string Nombre) 
        {
            this.nombre = Nombre;
        }

        // Modificar descripción del rol.
        public void ModificarDescripcion(string Descripcion) 
        {
            this.descripcion = Descripcion;
        }

        /// Para RazorPages: constructor sin argumentos, atributo ID es PrimaryKey para la base.
        public Rol() 
        {
        }

        public int ID { get; set; }

    }    
}
