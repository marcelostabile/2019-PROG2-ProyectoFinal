using System;

namespace Ignis 
{   
    public class Login 
    {
        public Login() 
        {
            
        }
        public static void IngresarAlSistema(Persona persona)
        {
            Console.WriteLine("Ingrese su mail: ");
            string mail = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Ingrese su contraseña: ");
            string contraseña = Convert.ToString(Console.ReadLine());


            if ((persona.Correo == mail)&&(persona.Contrasena == contraseña))
            {
               Console.WriteLine("Ha ingresado");   
            }
            else {
                 Console.WriteLine("Contraseña o Usuario incorrecto");
            }
        }
        public static void SalirsdelSistema(){
            Environment.Exit(0);
        }

                
    }
}
