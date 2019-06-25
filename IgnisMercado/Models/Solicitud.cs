using System;
using System.ComponentModel.DataAnnotations;

namespace IgnisMercado.Models 
{
    public class Solicitud : IGestionHoras, IObserverCosto
    {
        /// <summary>
        /// Para RazorPages: constructor sin argumentos.
        /// </summary>
        public Solicitud() 
        {
        }

        /// <summary>
        /// Para RazorPages: atributo PrimaryKey de la tabla.
        /// </summary>
        public int Id { get; set; } 

        public Solicitud(int modoDeContrato, string rolRequerido, int horasContratadas, string nivelExperiencia, string observaciones) 
        {
            this.ModoDeContrato = modoDeContrato;
            this.RolRequerido = rolRequerido;
            this.HorasContratadas = horasContratadas;
            this.NivelExperiencia = nivelExperiencia;
            this.Observaciones = observaciones;
            this.Status = true;

            // Calcular el costo de la solicitud al crear el objeto.
            ICosto Costo = new Costo();
            this.CostoSolicitud = Costo.CalcularCostoSolicitud(modoDeContrato, horasContratadas, nivelExperiencia);
        }

        /// <summary>
        /// Relación Proyecto:Solicitudes (uno-a-muchos)
        /// </summary>
        public Proyecto Proyecto { get; set; }

        /// <summary>
        /// Relación Tecnico:Solicitud (uno-a-uno)
        /// </summary>
        public Tecnico Tecnico { get; set; }

        /// <summary>
        /// Modo de Contratación - 1: horas y 2: Jornada.
        /// </summary>
        [Display(Name = "Modo de Contrato")]
       public int ModoDeContrato { get; set; }

        /// Es el rol que se está necesitando.
        [Display(Name = "Rol Requerido")]
        public string RolRequerido { get; set; }

        /// Registro de las horas contratadas por cliente.
        [Display(Name = "Horas Contratadas")]
        public int HorasContratadas { get; set; }

        /// Es el nivel de esperiencia que se necesita (Básico, Avanzado).
        [Display(Name = "Nivel Experiencia")]
        public string NivelExperiencia { get; set; }

        /// Observaciones de la solicitud (opcional).
        [Display(Name = "Observaciones")]
        public string Observaciones { get; set; }

        /// Costo de la solicitud.
        [Display(Name = "Costo Solicitud")]
        private int CostoSolicitud { get; set; }
        public int costoSolicitud 
        {
            get => this.CostoSolicitud;
            set => this.CostoSolicitud = value;
        }

        /// <summary>
        /// Estado de la solicitud.
        /// </summary>
        [Display(Name = "Status")]
        public bool Status { get; set; }

        /// <summary>
        /// Métodos para cambiar el status.
        /// </summary>
        public void StatusActivo() 
        {
            this.Status = true;
        }

        public void StatusInactivo() 
        {
            this.Status = false;
        }

        /// <summary>
        /// Método para agregar horas de contratación.
        /// </summary>
        public void AgregarHoras(int Horas) 
        {
            Check.Precondicion(Math.Abs(Horas) > 0, "El valor debe ser mayor a cero.");

            this.HorasContratadas += Math.Abs(Horas);

            // Actualizamos el costo de esta solicitud.
            this.ActualizarCostoSolicitudActiva();
        }

       /// <summary>
        // Método para restar horas de contratación.
       /// </summary>
        public void RestarHoras(int Horas) 
        {
            Check.Precondicion(Math.Abs(Horas) > 0, "El valor debe ser mayor a cero.");
            Check.Precondicion((this.HorasContratadas - Math.Abs(Horas)) >= 0, "El resultado no puede ser negativo.");

            if ((this.HorasContratadas  - Math.Abs(Horas)) >= 0) this.HorasContratadas -= Math.Abs(Horas);

            // Actualizamos el costo de esta solicitud.
            this.ActualizarCostoSolicitudActiva();
        }

       /// <summary>
        /// Este método actualiza el costo para la solicitud.
        /// La solicitud debe estar activa para que se realice esta modificación.
        /// Se ejecuta en dos oportunidades: 
        /// - cuando se agregan / restan horas
        /// - cuando se actualizan los precios.
        /// </summary>
        public void ActualizarCostoSolicitudActiva() 
        {
            ICosto Costo = new Costo(); 

            if (this.Status == true) 
            {
                this.CostoSolicitud = Costo.CalcularCostoSolicitud(this.ModoDeContrato, this.HorasContratadas, this.NivelExperiencia);
            }
        }

    }
}
