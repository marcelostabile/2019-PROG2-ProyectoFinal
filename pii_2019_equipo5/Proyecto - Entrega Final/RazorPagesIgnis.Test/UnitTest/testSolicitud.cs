using System;
using Xunit;
using RazorPagesIgnis;

namespace tests
{
    public class testsSolicitud
    {
        /// <summary>
        /// Verificamos la construcción de una solicitud.
        /// </summary>
        [Fact]
        public void construir_un_objeto_solicitud()
        {
            Solicitud s1 = new Solicitud(1,"Camarografo",12,"Avanzado","Buen Trabajo");

            string actual = string.Format(@"{0} {1} {2} {3} {4}",s1.ModoDeContrato, s1.RolRequerido, s1.HorasContratadas, s1.NivelExperiencia, s1.Observaciones);

            string expected = "1 Camarografo 12 Avanzado Buen Trabajo";


            Assert.Equal(expected, actual);
        }
        
        /// <summary>
        /// Probamos el metodo Agregar Horas.
        /// </summary>

        [Fact]
        public void MetodoAgregarHoras()
        {
            Solicitud s1 = new Solicitud(1,"Camarografo",12,"Avanzado","Buen Trabajo");

            s1.AgregarHoras(10);

            string actual = string.Format(@"{0} {1} {2} {3} {4}",s1.ModoDeContrato, s1.RolRequerido, s1.HorasContratadas, s1.NivelExperiencia, s1.Observaciones);

            string expected = "1 Camarografo 22 Avanzado Buen Trabajo";


            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Probamos el metodo Restar Horas.
        /// </summary>

        [Fact]
        public void MetodoRestarHoras()
        {
            Solicitud s1 = new Solicitud(1,"Camarografo",12,"Avanzado","Buen Trabajo");

            s1.RestarHoras(10);

            string actual = string.Format(@"{0} {1} {2} {3} {4}",s1.ModoDeContrato, s1.RolRequerido, s1.HorasContratadas, s1.NivelExperiencia, s1.Observaciones);

            string expected = "1 Camarografo 2 Avanzado Buen Trabajo";


            Assert.Equal(expected, actual);
        }

    }
}
