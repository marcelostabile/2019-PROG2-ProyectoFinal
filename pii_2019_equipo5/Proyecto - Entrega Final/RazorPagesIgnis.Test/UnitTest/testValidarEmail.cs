using System;
using Xunit;
using RazorPagesIgnis;

namespace tests
{
    public class testsValidarEmail 
    { 
        /// <summary> 
        /// Testeamos que la clase ValidarEmail realiza el comportamiento esperado.
        /// Implementamos el uso de InLineData para testear mediante parámetros.
        /// En el primer caso ingresamos "equipo@ucu.edu.uy" y debe retornar true.
        /// En el segundo caso ingresamos "equipo@uc" y debe retornar false.
        /// </summary>

        [Theory]
        [InlineData("equipo@ucu.edu.uy", true)]
        [InlineData("equipo@uc", false)]
        public void email_correcto_debe_retornar_true(string emailIngresado, bool resultado)
        {
            ValidarEmail ve = new ValidarEmail();

            bool actual = ve.EsUnEmailValido(emailIngresado);

            bool expected = resultado;

            Assert.Equal(expected, actual);
        }

    }
}