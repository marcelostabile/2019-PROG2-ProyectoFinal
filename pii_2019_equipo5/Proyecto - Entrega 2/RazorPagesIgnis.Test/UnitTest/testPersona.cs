using System;
using Xunit;
using RazorPagesIgnis;

namespace tests
{
    public class testsPersona
    {
        /// <summary>
        /// Verificamos la construcción de una persona.
        /// </summary>
        [Fact]
        public void construir_un_objeto_persona()
        {
            Persona p1 = new Persona("Leonardo", "leo@correo.ucu.edu.uy", "ZXCV1234");

            string actual = string.Format(@"{0} {1} {2} {3}", p1.Nombre, p1.Correo, p1.Contrasena, p1.Status);

            string expected = "Leonardo leo@correo.ucu.edu.uy ZXCV1234 True";

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Verificamos que se pueda inactivar un usuario.
        /// </summary>
        [Fact]
        public void cambiar_status_de_usuario_mediante_metodo_inactivar()
        {
            Persona p1 = new Persona("Leonardo", "leo@correo.ucu.edu.uy", "ZXCV1234"); 
            
            // por defecto queda activo. Enviamos un mensaje a p1 para inactivar el usuario.
            p1.Inactivar();
            
            bool actual = p1.Status;

            bool expected = false;

            Assert.Equal(expected.ToString(), actual.ToString());
        }

        /// <summary>
        /// Verificamos que se pueda activar un usuario.
        /// </summary>
        [Fact]
        public void cambiar_status_de_usuario_mediante_metodo_activar()
        {
            Persona p1 = new Persona("Leonardo", "leo@correo.ucu.edu.uy", "ZXCV1234"); 
            
            // por defecto queda activo. Enviamos un mensaje a p1 para inactivar el usuario.
            p1.Inactivar();

            // Enviamos un mensaje para cambiar status activándolo.
            p1.Activar();
            
            bool actual = p1.Status;

            bool expected = true;

            Assert.Equal(expected.ToString(), actual.ToString());
        }

    }
}
