using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IgnisMercado.Models
{   
    public class Tecnico : Persona
    { 
        /// <summary>
        /// Para RazorPages: constructor sin argumentos.
        /// </summary>
        public Tecnico() 
        {
        }

        /// <summary>
        /// Para RazorPages: atributo PrimaryKey de la tabla.
        /// Se agrega el parámetro 'new' debido a recomendación del compilador.
        /// </summary>
        public new int Id { get; set; } 

        /// <summary>
        /// El Técnico es la persona que se registra en la aplicación para ser contratado.
        /// Puede anotarse hasta en 3 roles (especialidades) y los Administradores lo asignan a Proyectos.
        /// 
        /// Esta es subclase de la clase Persona: hereda sus atributos y métodos.
        /// La clase Persona realiza una validación de Nombre, Correo y Contraseña.
        /// </summary>
        public Tecnico(string nombre, string correo, string contrasena, 
                        Int32 edad, string presentacion, string nivelExperiencia) 
                    : base(nombre, correo, contrasena) 
        { 
            Check.Precondicion(!string.IsNullOrEmpty(edad.ToString()), "La edad no puede ser nulo o vacío.");
            Check.Precondicion((edad > 0), "La edad debe ser mayor que cero.");

            this.Edad = edad;
            this.Presentacion = presentacion;
            this.NivelExperiencia = nivelExperiencia;   // 'Básico', 'Avanzado'.

            this.ListaSolicitudes = new List<Solicitud>();
        }   

        /// <summary>
        /// Relación Tecnico:Solicitud (uno-a-uno)
        /// </summary>
        public List<Solicitud> ListaSolicitudes { get; private set; }
        
        /// <summary>
        /// Edad. 
        /// 
        /// La edad debe ser mayor a cero, no puede ser nulo o vacío. 
        /// </summary>
        private Int32 Edad;
        public Int32 edad 
        {
            get { return this.Edad; }
            set { 
                Check.Precondicion(!string.IsNullOrEmpty(value.ToString()), "La edad no puede ser nulo o vacío.");
                Check.Precondicion((value > 0), "La edad debe ser mayor que cero.");

                this.Edad = value;

                Check.Postcondicion(this.Edad == value, "Edad no fue actualizado.");
                }
        }

        /// <summary>
        /// Presentación
        /// 
        /// El técnico puede incluir un texto para aclarar cosas, describir su forma de trabajo o intéreses.
        /// </summary>
        private string Presentacion;
        public string  presentacion
        {
            get => this.Presentacion;
            set => this.Presentacion = value;
        }

        /// <summary>
        /// Nivel de Experiencia
        /// 
        /// Nivel que el técnico se adjudica de experiencia.
        /// </summary>
        /// <value>"Básico", "Avanzado"</value>
        private string NivelExperiencia;
        public string  nivelExperiencia
        {
            get { return this.NivelExperiencia; }
            set { 
                Check.Precondicion((value == "Básico" || value == "Avanzado"), "Nivel de experiencia no admitido.");

                this.NivelExperiencia = value;

                Check.Postcondicion((value == "Básico" || value == "Avanzado"), "Nivel de experiencia no fue actualizado.");
                }
        }

        /// <summary>
        /// Método para cambio de nivel de experiencia.
        /// 
        /// Si actualmente es Básico, lo cambia a Avanzado.
        /// En caso contrario, lo cambia de Avanzado a Básico.
        /// </summary>
        public void CambiarNivelExperiencia() 
        {
            if (this.NivelExperiencia == "Básico") 
            {
                // Básico >> Avanzado.
                this.NivelExperiencia = "Avanzado";
            }
            else 
            {
                // Avanzado >> Básico.
                this.NivelExperiencia = "Básico";
            }
        }
    }
}
