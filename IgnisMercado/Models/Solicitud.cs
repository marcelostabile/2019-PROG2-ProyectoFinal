using System;

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

        /// Modo de Contratación
        /// 1: horas y 2: Jornada.
        private int ModoDeContrato;
        public int modoDeContrato 
        {
            get => this.ModoDeContrato;
            set => this.ModoDeContrato = value;
        }

        /// Es el rol que se está necesitando.
        private string RolRequerido;
        public string rolRequerido 
        {
            get => this.RolRequerido;
            set => this.RolRequerido = value;
        }

        /// Registro de las horas contratadas por cliente.
        private int HorasContratadas;
        public int horasContratadas 
        {
            get => this.HorasContratadas;
            set => this.HorasContratadas = value;
        }

        /// Es el nivel de esperiencia que se necesita (Básico, Avanzado).
        private string NivelExperiencia;
        public string nivelExperiencia 
        {
            get => this.NivelExperiencia;
            set => this.NivelExperiencia = value;
        }

        /// Observaciones de la solicitud (opcional).
        private string Observaciones;
        public string observaciones  
        {
            get => this.Observaciones;
            set => this.Observaciones = value;
        }

        /// La solicitud conoce el técnico cuando se le asigna.
        private Tecnico TecnicoAsignado;
        public Tecnico tecnicoAsignado 
        {
            get => this.TecnicoAsignado;
            protected set {}
        }

        /// Costo de la solicitud.
        private int CostoSolicitud;
        public int costoSolicitud 
        {
            get => this.CostoSolicitud;
            protected set {}
        }

        /// Estado de la solicitud.
        ///  
        /// 1: Activo / 0: Finalizada.
        private bool Status;
        public bool status 
        {
            get => this.Status;
            protected set {}
        }

        /// <summary>
        /// Método para asignar un técnico a esta solicitud.
        /// </summary>
        public void AsignarTecnico(Tecnico Tecnico) 
        {
            Check.Precondicion(!string.IsNullOrEmpty(Tecnico.ToString()), "El técnico no puede ser null o vacío.");

            this.TecnicoAsignado = Tecnico;
        }

        /// <summary>
        /// Método para agregar horas de contratación.
        /// El mensaje recibido debe tener como parámetro un valor positivo.
        /// Implementamos valor absoluto sobre la variable para evitar error en el cálculo.
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
        // El mensaje recibido debe tener como parámetro un valor positivo.
        // Implementamos valor absoluto sobre la variable para evitar error en el cálculo.
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
        /// 
        /// La solicitud debe estar activa para que se realice esta modificación.
        /// Se ejecuta en dos oportunidades: 
        /// - cuando se agregan / restan horas
        /// - cuando se actualizan los precios.
        /// </summary>
        public void ActualizarCostoSolicitudActiva() 
        {
            ICosto Costo = new Costo(); 

            if (this.status == true) 
            {
                this.costoSolicitud = Costo.CalcularCostoSolicitud(this.ModoDeContrato, this.HorasContratadas, this.NivelExperiencia);
            }
        }

        /// <summary>
        /// Métodos para cambiar el status.
        /// Activar(): si el proyecto está 'Cerrado' se cambia para 'Activo'.
        /// Cerrar(): si el proyecto está 'Activo' se cambia para 'Cerrado'.
        /// </summary>
        public void Activar() 
        {
            if (this.Status == false) this.CambiarStatus();
        }

        public void Cerrar() 
        {
            if (this.Status == true) this.CambiarStatus();
        }

        private void CambiarStatus() 
        {
            this.Status = !this.Status;
        }

    }
}
