using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesIgnis
{   
    public class Tecnico : Persona
    { 
        /// <summary>
        /// El Técnico es la persona que se registra en la aplicación para ser contratado.
        /// Puede anotarse hasta en 3 roles (especialidades) y los Administradores lo asignan a Proyectos.
        /// 
        /// Los campos obligatorios son: nombre y edad.
        /// Nombre, correo y contraseña los valida la clase Persona.
        /// </summary>
        public Tecnico(string Nombre, string Correo, string Contrasena, 
                        Int32 Edad, string Presentacion, string Nivel_experiencia) 
                    : base(Nombre, Correo, Contrasena) 
        { 
            Check.Precondicion(!string.IsNullOrEmpty(Edad.ToString()), "La edad no puede ser nulo o vacío.");
            Check.Precondicion((Edad > 0), "La edad debe ser mayor que cero.");

            this.edad = Edad;
            this.presentacion = Presentacion;                 // Texto de presentación de sí mismo.
            this.nivel_experiencia = Nivel_experiencia;       // 'Básico', 'Avanzado'.
        }

        /// Para RazorPages: constructor sin argumentos, atributo ID es PrimaryKey para la base.
        /// Para el atributo se agrega parámetro 'new' por advertencia de compilación.
        public Tecnico() 
        {
        }

        public new int ID { get; set; } 

        public ICollection<TecnicoSolicitud> TecnicoSolicitudes { get; set; }

        /// <summary>
        /// Edad. 
        /// 
        /// La edad debe ser mayor a cero, no puede ser nulo o vacío. 
        /// </summary>
        private Int32 edad;
        public Int32 Edad 
        {
            get { return this.edad; }
            set { 
                Check.Precondicion(!string.IsNullOrEmpty(value.ToString()), "La edad no puede ser nulo o vacío.");
                Check.Precondicion((value > 0), "La edad debe ser mayor que cero.");

                this.edad = value;

                Check.Postcondicion(this.Edad == value, "Edad no fue actualizado.");
                }
        }

        /// <summary>
        /// Presentación
        /// 
        /// El técnico puede incluir un texto para aclarar cosas, describir su forma de trabajo o intéreses.
        /// </summary>
        private string presentacion;
        public string  Presentacion
        {
            get => this.presentacion;
            set => this.presentacion = value;
        }

        /// <summary>
        /// Nivel de Experiencia
        /// 
        /// Nivel que el técnico se adjudica de experiencia.
        /// </summary>
        /// <value>"Básico", "Avanzado"</value>
        private string nivel_experiencia;
        public string  Nivel_experiencia
        {
            get { return this.nivel_experiencia; }
            set { 
                Check.Precondicion((value == "Básico" || value == "Avanzado"), "Nivel de experiencia no admitido.");

                this.nivel_experiencia = value;

                Check.Postcondicion((value == "Básico" || value == "Avanzado"), "Nivel de experiencia no fue actualizado.");
                }
        }

        /// <summary>
        /// Método para cambio de nivel de experiencia.
        /// 
        /// Si actualmente es Básico, lo cambia a Avanzado.
        /// Si está en Avanzado, no se realizan modificaciones.
        /// </summary>
        public void CambiarNivelDeExperienciaParaAvanzado() 
        {
            if (this.Nivel_experiencia == "Básico") this.Nivel_experiencia = "Avanzado";
        }
    }

}
