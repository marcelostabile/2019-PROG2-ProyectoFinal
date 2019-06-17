using System;
using Xunit;
using RazorPagesIgnis;

namespace tests
{
    public class testsValidarContrasena 
    { 
        /// <summary> 
        /// Testeamos que la clase ValidarContrasena realiza el comportamiento esperado.
        /// En este test implementamos el uso de InLineData para testear mediante parámetros.
        /// En el primer caso ingresamos "Abcd1234@" y debe retornar true.
        /// En el segundo caso ingresamos "4@c" y debe retornar false.
        /// </summary>

        [Theory]
        [InlineData("Abcd1234@", true)]
        [InlineData("4@c", false)]
        public void validamos_contrasena(string contrasena, bool resultado)
        {
            ValidarContrasena vc = new ValidarContrasena();

            bool actual = vc.EsUnaContrasenaValida(contrasena);

            bool expected = resultado;

            Assert.Equal(expected, actual);
        }

    }
}