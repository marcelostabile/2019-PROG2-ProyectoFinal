namespace IgnisMercado 
{ 
    public class Administrador : Persona 
    { 
        /// <summary>
        /// Para RazorPages: constructor sin argumentos.
        /// </summary>
        public Administrador() 
        {
        }

        /// <summary>
        /// Para RazorPages: atributo PrimaryKey de la tabla.
        /// Se agrega el parámetro 'new' debido a recomendación del compilador.
        /// </summary>
        public new int Id { get; set; } 

        /// <summary>
        /// El Administrador trabaja en el Centro Ignis.
        /// 
        /// Esta es subclase de la clase Persona: hereda sus atributos y métodos.
        /// La clase Persona realiza una validación de Nombre, Correo y Contraseña.
        /// </summary>
        /// <param name="nombre">Nombre del administrador</param>
        /// <param name="correo">Correo electrónico</param>
        /// <param name="contrasena">Contraseña</param>      
        public Administrador(string Nombre, string Correo, string Contrasena) 
                    : base(Nombre, Correo, Contrasena) 
        { 
        }

    }
}
