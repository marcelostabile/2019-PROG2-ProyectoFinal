using System;

namespace RazorPagesIgnis
{ 
    public class Administrador : Persona 
    { 
        /// <summary>
        /// El Administrador es la persona que trabaja en el Centro Ignis.
        /// 
        /// Los atributos obligatorios son nombre y edad. 
        /// Nombre, correo y contraseña los valida la clase Persona.
        /// </summary>
        /// <param name="nombre">Nombre del administrador</param>
        /// <param name="correo">Correo electrónico</param>
        /// <param name="contrasena">Contraseña</param>      
        public Administrador(string nombre, string correo, string contrasena) 
                        : base(nombre, correo, contrasena) 
        { 
        }

        /// <summary>
        /// Para RazorPages: constructor sin argumentos, atributo ID es PrimaryKey para la base.
        /// Para el atributo se agrega parámetro 'new' por advertencia de compilación.
        /// </summary>
        public Administrador() 
        {
        }

        public new int ID { get; set; }   

    }
}
