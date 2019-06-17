using System;

namespace RazorPagesIgnis 
{
    public class Rol : IRol
    {
        /// <summary>
        /// Rol del técnica.
        /// </summary>
        public Rol(string Nombre, string Descripción) 
        {
            this.nombre = Nombre;
            this.descripcion = Descripción;
        }

        // Nombre del rol.
        private string nombre;
        public string Nombre  
        { 
            get => this.nombre; 
            protected set {}
        }

        // Descripción del rol (opcional).
        private string descripcion;
        public string Descripcion  
        { 
            get => this.descripcion; 
            protected set {}
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
