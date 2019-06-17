using System;

namespace RazorPagesIgnis 
{   
    /// <summary>
    /// Esta clase permite implementar el manejo de Precondiciones, Postcondiciones e Invariantes 
    /// durante la ejecución de la aplicación.
    /// </summary>
    public class Check 
    { 
        /// <summary>
        /// Para RazorPages: constructor sin argumentos, atributo ID es PrimaryKey para la base.
        /// </summary>
        public Check() 
        {
        }

        public int ID { get; set; }

        /// <summary>
        /// Precondiciones.
        /// </summary>
        public class PrecondicionExcepcion : Exception 
        {
            public PrecondicionExcepcion(string mensaje) : base (mensaje) {} 
        }

        public static void Precondicion(bool condicion, string mensaje) 
        { 
            if (!condicion) 
            { 
                throw new PrecondicionExcepcion(mensaje);
            }
        }

        /// <summary>
        /// Postcondiciones.
        /// </summary>
        public class PostcondicionExcepcion : Exception 
        {
            public PostcondicionExcepcion(string mensaje) : base (mensaje) {} 
        }

        public static void Postcondicion(bool condicion, string mensaje) 
        { 
            if (!condicion) 
            { 
                throw new PostcondicionExcepcion(mensaje);
            }
        }

        /// <summary>
        /// Invariantes.
        /// </summary>
        public class InvarianteExcepcion : Exception 
        {
            public InvarianteExcepcion(string mensaje) : base (mensaje) {} 
        }

        public static void Invariante(bool condicion, string mensaje) 
        { 
            if (!condicion) 
            { 
                throw new InvarianteExcepcion(mensaje);
            }
        }

    }
}
