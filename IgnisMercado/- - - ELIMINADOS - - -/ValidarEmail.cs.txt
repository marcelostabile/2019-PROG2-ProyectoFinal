// using System;
// using System.Text.RegularExpressions;

// namespace IgnisMercado.Models 
// {   
//     public class ValidarEmail : IValidarEmail
//     { 
//         /// <summary>
//         /// La clase ValidarEmail implementa un método para validar 
//         /// la dirección de correo electrónico ingresada.
//         /// 
//         /// Recibe un mensaje cuyo parámetro es una dirección de email.
//         /// </summary>
//         /// <returns>True = Contraseña válida; False = contraseña inválida</returns>
//         public bool EsUnEmailValido(string email) 
//         {
//             // Se compara si el email ingresado cumple la forma de la Expresión Regular definida a continuación.
//             String expresion = @"\w+([\w\.\-%+])*@\w+([\w\.\-%+])*\.\w{2,5}";

//             if (Regex.IsMatch(email, expresion)) 
//             {
//                 if (Regex.Replace(email, expresion, String.Empty).Length == 0)
//                 {
//                     return true; 
//                 }
//                 else
//                 {
//                     return false;
//                 }
//             }
//             else
//             {
//                 return false;
//             }
//         }

//     }
// }