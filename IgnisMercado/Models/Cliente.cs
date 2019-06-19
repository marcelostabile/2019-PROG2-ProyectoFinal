using System.Collections.Generic;

namespace IgnisMercado.Models
{   
    public class Cliente : Persona 
    {
        /// <summary>
        /// Para RazorPages: constructor sin argumentos.
        /// </summary>
        public Cliente() 
        {
        }

        /// <summary>
        /// Para RazorPages: atributo PrimaryKey de la tabla.
        /// Se agrega el parámetro 'new' debido a recomendación del compilador.
        /// </summary>
        public new int Id { get; set; } 

        /// <summary>
        /// El cliente es la persona que tiene el proyecto y contrata los servicios del técnico.
        /// 
        /// Esta es subclase de la clase Persona: hereda sus atributos y métodos.
        /// La clase Persona realiza una validación de Nombre, Correo y Contraseña.
        /// </summary>
        /// <param name="nombre">Nombre del cliente</param>
        /// <param name="correo">Correo electrónico</param>
        /// <param name="contrasena">Contraseña</param>        
        public Cliente(string Nombre, string Correo, string Contrasena) 
                    : base(Nombre, Correo, Contrasena) 
        { 
            this.ListaProyectos = new List<Proyecto>();
        }

        /// <summary>
        ///  Lista de Proyectos del cliente.
        /// 
        /// Relación Cliente:Proyectos (uno-a-muchos)
        /// </summary>
        private List<Proyecto> ListaProyectos;

        /// <summary>
        /// Este método agrega un nuevo proyecto a la lista de proyectos del cliente.
        /// </summary>
        /// <param name="ProyectoNuevo">Proyecto del cliente.</param>
        public void AgregarProyecto(Proyecto ProyectoNuevo) 
        {
            this.ListaProyectos.Add(ProyectoNuevo);
        }

    }
}
