using System;
using System.Collections.Generic;
using Xunit;
using RazorPagesIgnis;

namespace tests
{
    public class testsProyecto
    {
        /// <summary>
        /// Verificamos la construcción de un objeto Proyecto.
        /// </summary>
        [Fact]
        public void construir_un_proyecto()
        {
            Proyecto proyecto1 = new Proyecto("Proyecto1", "descripcion");

            string actual = string.Format(@"{0} {1}", proyecto1.Nombre, proyecto1.Descripcion);
 
            string expected = "Proyecto1 descripcion";

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Probamos el metodo cerrar, Metodo que cambia el status del proyecto y sus solicitudes asosiadas.
        /// Para ello se necesita tener una solicitud ingresada.
        /// </summary>

        [Fact]
        public void Probar_Metodo_Cerrar()
        {
            Proyecto proyecto1 = new Proyecto("Proyecto1", "descripcion");
            Solicitud sol1 = new Solicitud(1,"Camarografo",10,"Avanzado","");

            proyecto1.AgregarSolicitud(sol1);
            proyecto1.Cerrar();
            
            string actual = string.Format(@"{0} {1}", proyecto1.Status, sol1.Status);
 
            string expected = "False False";

            Assert.Equal(expected, actual);
        }
        
      /// <summary>
      /// Probamos el metodo cerrar, Metodo que calcula el costo total del proyecto para ello se calculan el costo de las solicitudes asosiadas.
      /// Para ello se necesita tener al menos una solicitud ingresada.
      /// </summary>
      
        [Fact]
        public void Probar_InformarCostoTotalProyecto()
        {
            Proyecto proyecto1 = new Proyecto("Proyecto1", "descripcion");
            Solicitud sol1 = new Solicitud(1,"Camarografo",10,"Avanzado","");

            proyecto1.AgregarSolicitud(sol1);
            proyecto1.InformarCostoTotalProyecto();
            
            string actual = string.Format(@"{0}",sol1.CostoSolicitud);
 
            string expected = "3040";

            Assert.Equal(expected, actual);
        }
    }
}
