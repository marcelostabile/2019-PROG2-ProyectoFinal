namespace IgnisMercado.Models 
{   
    public class ValidarContrasena  : IValidarContrasena
    { 
        /// <summary>
        /// La clase ValidarContrasena implementa un método para validar una contraseña ingresada.
        /// controlando que tenga un formato válido.
        /// 
        /// Actualmente controlamos que no sea 'vacío', que no sea 'null' y debe 
        /// tener un largo mayor a 4 carácteres.
        /// </summary>
        /// <returns>True = Contraseña válida; False = contraseña inválida</returns>
        public bool EsUnaContrasenaValida(string valor) 
        {
            if ( (string.IsNullOrEmpty(valor)) || (valor.Length < 4) ) 
            {
                return false;
            }
            else 
            {
                return true; 
            }
        }
    }

}