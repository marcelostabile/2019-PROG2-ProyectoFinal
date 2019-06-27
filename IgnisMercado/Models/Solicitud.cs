using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IgnisMercado.Models 
{ 
    public class Solicitud : IGestionHoras, IObserverCosto
    { 
        /// <summary>
        /// Constructor sin argumentos para Razorpages.
        /// </summary>
        public Solicitud() 
        {
        }

        public Solicitud(int modoDeContrato, string rolRequerido, int horasContratadas, string nivelExperiencia, string observaciones) 
        {
            this.ModoDeContrato = modoDeContrato;
            this.RolRequerido = rolRequerido;
            this.HorasContratadas = horasContratadas;
            this.NivelExperiencia = nivelExperiencia;
            this.Observaciones = observaciones;
            this.Status = true;

            // Cuando instanciamos el objeto, calculamos su costo de acuerdo a los valores ingresados.
            ICosto Costo = new Costo();

            this.CostoSolicitud = Costo.CalcularCostoSolicitud(modoDeContrato, horasContratadas, nivelExperiencia);
        }

        /// <summary>
        ///  Clave primaria.
        /// </summary>
        [Key]
        public int SolicitudId { get; set; }

        public IList<RelacionProyectoSolicitud> RelacionProyectoSolicitud { get; set; }

        /// <summary>
        /// Modo de Contratación (1: horas y 2: Jornada).
        /// </summary>
        [Display(Name = "Modo de Contrato")]
       public int ModoDeContrato { get; set; }

        /// Es el rol que el cliente necesita.
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(45)]
        [Display(Name = "Rol Requerido")]
        public string RolRequerido { get; set; }

        /// Registro de las horas contratadas por cliente.
        [Display(Name = "Horas Contratadas")]
        public int HorasContratadas { get; set; }

        /// Es el nivel de experiencia que se necesita (Básico, Avanzado).
        [Display(Name = "Nivel Experiencia")]
        public string NivelExperiencia { get; set; }

        /// Observaciones de la solicitud.
        [Display(Name = "Observaciones")]
        [StringLength(300)]
        public string Observaciones { get; set; }

        /// <summary>
        /// Estado de la solicitud.
        /// </summary>
        [Display(Name = "Status")]
        public bool Status { get; set; }

        /// Costo de la solicitud.
        private int CostoSolicitud { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Costo Solicitud")]
        public int costoSolicitud 
        {
            get => this.CostoSolicitud;
            set => this.CostoSolicitud = value;
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
        /// Este método actualiza el costo de la solicitud (debe tener status activo).
        /// Se ejecuta en dos oportunidades: 
        /// - cuando se agregan / restan horas
        /// - cuando se actualizan los precios.
        /// </summary>
        public void ActualizarCostoSolicitudActiva() 
        {
            ICosto Costo = new Costo(); 

            if (this.Status == true) 
            {
                this.costoSolicitud = Costo.CalcularCostoSolicitud(this.ModoDeContrato, this.HorasContratadas, this.NivelExperiencia);
            }
        }

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

    }
}
