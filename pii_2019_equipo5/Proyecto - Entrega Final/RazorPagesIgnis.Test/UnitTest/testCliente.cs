using System;
using Xunit;
using RazorPagesIgnis;

namespace tests
{
    public class testsCliente
    {
        /// <summary>
        /// Verificamos la construcción de un cliente.
        /// </summary>
        [Fact]
        public void construir_un_objeto_cliente()
        {
            Cliente c1 = new Cliente("Leonardo", "leo@correo.ucu.edu.uy", "ZXCV1234");

            string actual = string.Format(@"{0} {1} {2} {3}",c1.Nombre, c1.Correo, c1.Contrasena, c1.Status);

            string expected = "Leonardo leo@correo.ucu.edu.uy ZXCV1234 True";

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Verificamos que se pueda inactivar un usuario.
        /// </summary>
        [Fact]
        public void cambiar_status_de_usuario_mediante_metodo_inactivar()
        {
            Cliente c1 = new Cliente("Leonardo", "leo@correo.ucu.edu.uy", "ZXCV1234"); 
            
            // por defecto queda activo. Enviamos un mensaje a p1 para inactivar el usuario.
            c1.Inactivar();
            
            bool actual = c1.Status;

            bool expected = false;

            Assert.Equal(expected.ToString(), actual.ToString());
        }

        /// <summary>
        /// Verificamos que se pueda activar un usuario.
        /// </summary>
        [Fact]
        public void cambiar_status_de_usuario_mediante_metodo_activar()
        {
            Cliente c1 = new Cliente("Leonardo", "leo@correo.ucu.edu.uy", "ZXCV1234"); 
            
            // por defecto queda activo. Enviamos un mensaje a p1 para inactivar el usuario.
            c1.Inactivar();

            // Enviamos un mensaje para cambiar status activándolo.
            c1.Activar();
            
            bool actual = c1.Status;

            bool expected = true;

            Assert.Equal(expected.ToString(), actual.ToString());
        }

    }
}
