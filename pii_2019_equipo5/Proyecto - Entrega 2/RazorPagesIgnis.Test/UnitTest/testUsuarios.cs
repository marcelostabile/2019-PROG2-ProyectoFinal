using System;
using System.Collections.Generic;
using Xunit;
using RazorPagesIgnis;

namespace tests
{
    public class testsUsuarios 
    {
        [Fact]
        public void crear_lista_guardar_tecnicos() 
        {
            // creamos dos técnicos.
            Tecnico t1 = new Tecnico("Gonzalo", "gonza@correo.com", "abc123", 40, "mepresento", "Avanzado");
            Tecnico t2 = new Tecnico("Marcelo", "marce@correo.ucu.edu.uy", "abc123", 33, "mipresentacion", "Básico");
        
            // creamos instancia de la clase Usuarios.
            Usuarios usu = new Usuarios();

            // agregamos técnicos a la lista de técnicos.
            usu.AgregarTecnico(t1);
            usu.AgregarTecnico(t2);

            // test.
            Assert.Contains(t1, usu.ListaDeTecnicos);
        }

        [Fact]
        public void crear_lista_de_tecnicos_y_eliminar_un_tecnico() 
        {
            // creamos dos técnicos.
            Tecnico t1 = new Tecnico("Gonzalo", "gonza@correo.com", "abc123", 40, "mepresento", "Avanzado");
            Tecnico t2 = new Tecnico("Marcelo", "marce@correo.ucu.edu.uy", "abc123", 33, "mipresentacion", "Básico");
        
            // creamos instancia de la clase Usuarios.
            Usuarios usu = new Usuarios();

            // agregamos técnicos a la lista de técnicos.
            usu.AgregarTecnico(t1);
            usu.AgregarTecnico(t2);

            // eliminar un técnico
            usu.EliminarTecnico(t1);

            // test.
            Assert.DoesNotContain(t1, usu.ListaDeTecnicos);
        }

    }
}
