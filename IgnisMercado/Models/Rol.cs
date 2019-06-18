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

        /// <summary>
        /// Rol del técnica.
        /// </summary>
        public Rol(string nombre, string descripcion) 
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        /// Nombre del rol.
        private string Nombre;
        public string nombre  
        { 
            get => this.Nombre; 
            set => this.Nombre = value;
        }

        /// Descripción del rol (opcional).
        private string Descripcion;
        public string descripcion  
        { 
            get => this.Descripcion; 
            set => this.Descripcion = value;
        }
        
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
