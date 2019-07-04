using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IgnisMercado.Models
{   
    /// <summary>
    /// Esta clase tiene la responsabiliad de conocer los precios definidos por el centro.
    /// Decimos que cumple con EXPERT, porque es la unica clase que conoce esta informacion y 
    /// por lo tanto su única razon de cambio.
    /// 
    /// Patrón Singleton: durante la ejecusión surgió el problema que se creaban muchas instancias de esta clase 
    /// (por distintas razones), lo que implica que existen muchos objetos que contienen los precios. 
    /// Esto no es deseable porque cualquier cambio de precios implica modificarlos a todos, no podemos tener múltiples listas de precios 
    /// coexistiendo. Para solucionar este problema aplicamos Singleton con el objetivo de tener una única instancia de esta clase 
    /// durante la ejecusión del programa. Esto nos asegura que los precios solo existen en un único objeto en toda la aplicación.
    /// </summary>
    public class Costo : ISujetoCosto, ICosto
    { 
        // Para patrón Singleton: declaración static.
        private static Costo costoInstancia;

        // Para patrón Singleton: private.
        private Costo() 
        {
            this.primeraHoraBasico = 380;
            this.costoHoraBasico = 150;
            this.jornadaBasico = 1200;

            this.primeraHoraAvanzado = 520;
            this.costoHoraAvanzado = 280;
            this.jornadaAvanzado = 2000;

            this.horaJornada = 6;
        }

        // Para patrón Singleton: método obtener instancia.
        public static Costo obtenerInstancia() 
        {
            if (costoInstancia == null)
            {
                costoInstancia = new Costo();
            }

            return costoInstancia;
        }

        // Para patrón Singleton: seeding en el contexto.
        // Se define este método para uso del contexto y el patrón Singleton.
        public void SeedCostoSingleton(ApplicationContext _context)
        {
            _context.Costos.AddRange(
                new Costo 
                {
                    CostoHoraBasico = 150,
                    CostoHoraAvanzado = 280,
                    PrimeraHoraBasico = 380,
                    PrimeraHoraAvanzado = 520,
                    JornadaAvanzado = 2000,
                    JornadaBasico = 1200,
                    HoraJornada = 6
                }
            );

            _context.SaveChanges();
        }

        //public static Costo CostoInstancia { get => costoInstancia; set => costoInstancia = value; }

        /// <summary>
        /// Para RazorPages: atributo PrimaryKey de la tabla.
        /// </summary>
        public int Id { get; set; }

        //cantidad de horas por jornada
        private int horaJornada;
        [Range(1, 24)]
        [Display(Name = "Cantidad de Horas por Jornada")]
        public int HoraJornada 
        {
            get => this.horaJornada;
            set => this.horaJornada = value;
        }
        
        //costo basico
        private int costoHoraBasico;
        [DataType(DataType.Currency)]
        [Column(TypeName = "integer(18)")]
        [Display(Name = "Hora Adicional")]
        public int CostoHoraBasico 
        {
            get => this.costoHoraBasico;
            set => this.costoHoraBasico = value;
        }

        //costo avanzado
        private int costoHoraAvanzado;
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Hora Adicional")]
        public int CostoHoraAvanzado 
        {
            get => this.costoHoraAvanzado;
            set => this.costoHoraAvanzado = value;
        }

        //primera hora
        private int primeraHoraBasico;
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Primer Hora")]
        public int PrimeraHoraBasico 
        {
            get => this.primeraHoraBasico;
            set => this.primeraHoraBasico = value;
        }

        private int primeraHoraAvanzado;
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Primer Hora")]
        public int PrimeraHoraAvanzado 
        {
            get => this.primeraHoraAvanzado;
            set => this.primeraHoraAvanzado = value;
        }

        private int jornadaBasico;
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Jornada")]
        public int JornadaBasico
        {
            get => this.jornadaBasico;
            set => this.jornadaBasico = value;
        }

        private int jornadaAvanzado;
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Jornada")]
        public int JornadaAvanzado
        {
            get => this.jornadaAvanzado;
            set => this.jornadaAvanzado = value;
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
