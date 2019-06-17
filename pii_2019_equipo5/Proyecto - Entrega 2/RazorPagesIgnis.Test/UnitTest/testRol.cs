using System;
using System.Collections.Generic;
using Xunit;
using RazorPagesIgnis;

namespace tests
{
    public class testsRol
    {

        [Fact]
        public void construir_un_rol()
        {
            Rol rol1 = new Rol("Rol1", "descripcion");

            string actual = string.Format(@"{0} {1}", rol1.Nombre, rol1.Descripcion);
 
            string expected = "Rol1 descripcion";

            Assert.Equal(expected, actual);
        }
    }
}
