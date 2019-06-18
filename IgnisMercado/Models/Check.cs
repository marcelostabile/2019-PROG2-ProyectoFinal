using System;

namespace IgnisMercado.Models 
{ 
    public class Check 
    { 
        /// <summary>
        /// Esta clase permite implementar el manejo de Precondiciones, Postcondiciones e Invariantes 
        /// durante la ejecución de la aplicación.
        /// </summary>
        public Check() 
        {
        }

        /// <summary>
        /// Para RazorPages: atributo PrimaryKey de la tabla.
        /// </summary>
        public int Id { get; set; } 
    
        /// <summary>
        /// Precondiciones.
        /// </summary>
        public class PrecondicionExcepcion : Exception 
        {
            public PrecondicionExcepcion(string Mensaje) : base (Mensaje) {} 
        }

        public static void Precondicion(bool condicion, string Mensaje) 
        { 
            if (!condicion) 
            { 
                throw new PrecondicionExcepcion(Mensaje);
            }
        }

        /// <summary>
        /// Postcondiciones.
        /// </summary>
        public class PostcondicionExcepcion : Exception 
        {
            public PostcondicionExcepcion(string Mensaje) : base (Mensaje) {} 
        }

        public static void Postcondicion(bool condicion, string Mensaje) 
        { 
            if (!condicion) 
            { 
                throw new PostcondicionExcepcion(Mensaje);
            }
        }

        /// <summary>
        /// Invariantes.
        /// </summary>
        public class InvarianteExcepcion : Exception 
        {
            public InvarianteExcepcion(string Mensaje) : base (Mensaje) {} 
        }

        public static void Invariante(bool condicion, string Mensaje) 
        { 
            if (!condicion) 
            { 
                throw new InvarianteExcepcion(Mensaje);
            }
        }

    }
}
