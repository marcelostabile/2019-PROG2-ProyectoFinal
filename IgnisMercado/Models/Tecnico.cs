using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IgnisMercado.Areas.Identity.Data;

namespace IgnisMercado.Models
{   
    public class Tecnico : ApplicationUser
    { 
        /// <summary>
        /// El Técnico es la persona que se registra en la aplicación para ser contratado.
        /// Puede anotarse hasta en 3 roles (especialidades) y los Administradores lo asignan a Proyectos.
        /// </summary>
        public Tecnico() 
        {
        }

        /// <summary>
        /// Relación Tecnico:Solicitud (uno-a-uno)
        /// </summary>
        public IList<Solicitud> ListaSolicitudes { get; private set; }

        /// <summary>
        /// Presentación
        /// El técnico puede incluir un texto para aclarar cosas, describir su forma de trabajo o intéreses.
        /// </summary>
        [Display(Name = "Presentación")]
        private string Presentacion { get; set; }

        // /// <summary>
        // /// Nivel de Experiencia que el técnico se adjudica de experiencia.
        // /// </summary>
        // /// <value>"Básico", "Avanzado"</value>
        // public string NivelExperiencia { get; protected set; }

        // /// <summary>
        // /// Método para cambiar el nivel de experiencia a Básico.
        // /// </summary>
        // public void CambiarNivelExperienciaBasico()
        // {
        //     this.NivelExperiencia = "Básico";
        // }

        // /// <summary>
        // /// Método para cambiar el nivel de experiencia a Avanzado.
        // /// </summary>
        // public void CambiarNivelExperienciaAvanzado()
        // {
        //     this.NivelExperiencia = "Avanzado";
        // }

    }
}
