namespace IgnisMercado.Models 
{   
    public class Costo : ISujetoCosto, ICosto
    { 
        /// <summary>
        /// Esta clase conoce el costo por hora para cada modo de contratación y catégoria de técnico.
        /// Tiene la responsabilidad de calcular el costo de una solicitud.
        /// </summary>
        public Costo() 
        {
            this.costoHoraBasico = 150;
            this.costoHoraAvanzado = 280;

            this.primeraHoraBasico = 380;
            this.primeraHoraAvanzado = 520;

            this.jornadaAvanzado=2000;
            this.jornadaBasico=1200;

            this.horaJornada=6;
        }

        /// <summary>
        /// Para RazorPages: atributo PrimaryKey de la tabla.
        /// </summary>
        public int Id { get; set; }

        //cantidad de horas por jornada
        private int horaJornada;
        public int HoraJornada 
        {
            get => this.horaJornada;
            protected set {}
        }
        
        //costo basico
        private int costoHoraBasico;
        public int CostoHoraBasico 
        {
            get => this.costoHoraBasico;
            protected set {}
        }

        //costo avanzado
        private int costoHoraAvanzado;
        public int CostoHoraAvanzado 
        {
            get => this.costoHoraAvanzado;
            protected set {}
        }

        //primera hora
        private int primeraHoraBasico;
        public int PrimeraHoraBasico 
        {
            get => this.primeraHoraBasico;
            protected set {}
        }

        private int primeraHoraAvanzado;
        public int PrimeraHoraAvanzado 
        {
            get => this.primeraHoraAvanzado;
            protected set {}
        }

        private int jornadaBasico;
        public int JornadaBasico
        {
            get => this.jornadaBasico;
            protected set {}
        }

        private int jornadaAvanzado;
        public int JornadaAvanzado
        {
            get => this.jornadaAvanzado;
            protected set {}
        }

        public void ModificarHoraJornada(int nuevoCosto) 
        {
            this.horaJornada = nuevoCosto;

            Notificar();
        }
        
        public void ModificarCostoHoraBasico(int nuevoCosto) 
        {
            this.costoHoraBasico = nuevoCosto;

            Notificar();
        }

        public void ModificarCostoHoraAvanzado(int nuevoCosto) 
        {
            this.costoHoraAvanzado = nuevoCosto;

            Notificar();
        }

        public void ModificarPrimeraHoraBasico(int nuevoCosto) 

        {
            this.primeraHoraBasico = nuevoCosto;

            Notificar();
        }

        public void ModificarPrimeraHoraAvanzado(int nuevoCosto) 
        {
            this.primeraHoraAvanzado = nuevoCosto;

            Notificar();
        }

        public void ModificarJornadaBasico(int nuevoCosto) 
        {
            this.jornadaBasico = nuevoCosto;

            Notificar();
        }

        public void ModificarJornadaAvanzado(int nuevoCosto) 
        {
            this.jornadaAvanzado = nuevoCosto;

            Notificar();
        }

        public int CalcularCostoSolicitud(int ModoDeContrato,int HorasContratadas,string NivelExperiencia) 
        {
            int CostoTotalSolicitud = 0;
            int modulo = 0;

            if (ModoDeContrato == 1 )
            {
                if (NivelExperiencia == "Avanzado" )
                {
                    CostoTotalSolicitud = (HorasContratadas -1) * this.CostoHoraAvanzado;
                    CostoTotalSolicitud = CostoTotalSolicitud + this.primeraHoraAvanzado;
                }
                else
                {
                    CostoTotalSolicitud = (HorasContratadas -1) * this.CostoHoraBasico;
                    CostoTotalSolicitud = CostoTotalSolicitud + this.primeraHoraBasico;                      
                }
            }
            else// si modocontrato es 2 es por jornada
            {
                if (NivelExperiencia == "Básico" )
                {
                    modulo= HorasContratadas / this.horaJornada;
                    int resta = HorasContratadas - (modulo * this.horaJornada);
                    CostoTotalSolicitud = (resta*this.costoHoraBasico) + (modulo * this.jornadaBasico);
                }
                else 
                {
                    modulo= HorasContratadas / this.horaJornada;
                    int resta = HorasContratadas - (modulo * this.horaJornada);
                    CostoTotalSolicitud = (resta*this.costoHoraAvanzado) + (modulo * this.jornadaAvanzado);
                }
            }

            return CostoTotalSolicitud;
        }
    }
}
