using System;
using System.Collections.Generic;

namespace RazorPagesIgnis
{   
    public class Cliente : Persona 
    {
        /// <summary>
        /// El cliente es la persona que tiene el proyecto y contrata los servicios del técnico.
        /// 
        /// Nombre, correo y contraseña: se chequean en la clase Persona.
        /// </summary>
        /// <param name="nombre">Nombre del cliente</param>
        /// <param name="correo">Correo electrónico</param>
        /// <param name="contrasena">Contraseña</param>        
        public Cliente(string nombre, string correo, string contrasena) 
                    : base(nombre, correo, contrasena) 
        { 
            List<Proyecto> ListaDeProyectos = new List<Proyecto>();
            this.listaProyectos = ListaDeProyectos;
        }

        /// <summary>
        /// Para RazorPages: constructor sin argumentos, atributo ID es PrimaryKey para la base.
        /// Para el atributo se agrega parámetro 'new' por advertencia de compilación.
        /// </summary>
        public Cliente() 
        {
        }

        public new int ID { get; set; }

        /// <summary>
        ///  Lista de Proyectos del cliente.
        /// </summary>
        private List<Proyecto> listaProyectos;
        public List<Proyecto> ListaProyectos 
        {
            get => this.listaProyectos;
            protected set {}
        }

        /// <summary>
        /// Este método agrega un nuevo proyecto a la lista de proyectos del cliente.
        /// </summary>
        /// <param name="ProyectoNuevo">Proyecto del cliente.</param>
        public void AgregarProyecto(Proyecto ProyectoNuevo) 
        {
            this.listaProyectos.Add(ProyectoNuevo);
        }

    }
}
